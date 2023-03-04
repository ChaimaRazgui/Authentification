using System.ComponentModel.DataAnnotations;
using MediatR;
using Naxxum.WeeCare.Authentification.Domain.Shared;

namespace Naxxum.WeeCare.Authentification.Application.DTOs.Auth;

public record LoginDto([Required] string Username, [Required] string Password) : IRequest<OperationResult<UserWithTokenDto>>;