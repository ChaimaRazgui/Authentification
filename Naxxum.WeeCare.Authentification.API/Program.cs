using Naxxum.WeeCare.Authentification.API.Extensions;
using Naxxum.WeeCare.Authentification.Application.Extensions;
using Naxxum.WeeCare.Authentification.Infrastructure.Data;
using Naxxum.WeeCare.Authentification.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSqlServer<AppDbContext>(
    builder.Configuration.GetConnectionString("DefaultConnection"), null,
    optionsBuilder => optionsBuilder.EnableSensitiveDataLogging(builder.Environment.IsDevelopment()));
// Add services to the container.

builder.Services
    .AddApiServices(builder.Configuration)
    .AddApplicationServices(builder.Configuration)
    .AddInfrastructureServices(builder.Configuration);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
await AppDbContextSeeder.SeedAsync(app.Services);
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
