using System.ComponentModel.DataAnnotations;
using MediatR;
using Naxxum.WeeCare.Authentification.Application.DTOs.Users;
using Naxxum.WeeCare.Authentification.Domain.Shared;

namespace Naxxum.WeeCare.Authentification.Application.DTOs.Auth;

public record RegisterDto([Required, StringLength(50)] string Username, [Required, StringLength(50)] string Password) : IRequest<OperationResult<UserDto>>;