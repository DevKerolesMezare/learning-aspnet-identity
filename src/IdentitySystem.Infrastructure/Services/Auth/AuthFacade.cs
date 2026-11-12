using IdentitySystem.Application.DTOs;
using IdentitySystem.Application.Interfaces;
using IdentitySystem.Application.Results;

namespace IdentitySystem.Infrastructure.Services.Auth;

public class AuthFacade(
    UserAuthService userAuthService,
    RoleAuthService roleAuthService)
    : IAuthService
{
    public Task<AuthResult> RegisterAsync(RegisterRequest request) =>
        userAuthService.RegisterAsync(request);

    public Task<AuthResult> LoginAsync(LoginRequest request) =>
        userAuthService.LoginAsync(request);

    public Task<AuthResult> AssignRoleAsync(AssignRoleRequest request) =>
        roleAuthService.AssignRoleAsync(request);
}
