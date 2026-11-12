using IdentitySystem.Application.DTOs;
using IdentitySystem.Application.Results;

namespace IdentitySystem.Application.Interfaces;

public interface IAuthService
{
    Task<AuthResult> RegisterAsync(RegisterRequest request);
    Task<AuthResult> LoginAsync(LoginRequest request);
    Task<AuthResult> AssignRoleAsync(AssignRoleRequest request);
}
