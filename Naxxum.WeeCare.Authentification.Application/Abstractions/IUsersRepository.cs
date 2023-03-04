using System.Linq.Expressions;
using Naxxum.WeeCare.Authentification.Domain.Entities;

namespace Naxxum.WeeCare.Authentification.Application.Abstractions;

public interface IUsersRepository : IRepository<User>
{
    Task<User?> GetUserByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<User?> GetUserAsync(Expression<Func<User, bool>> expression, CancellationToken cancellationToken = default);
}