using IdentitySystem.Application.DTOs;
using IdentitySystem.Application.Interfaces;
using IdentitySystem.Application.Results;
using IdentitySystem.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace IdentitySystem.Infrastructure.Services.Auth;   

public class UserAuthService(
    UserManager<ApplicationUser> userManager,
    RoleManager<ApplicationRole> roleManager,
    ITokenService tokenService)
{
    private const string AdminRole = "Admin";

    public async Task<AuthResult> RegisterAsync(RegisterRequest request)
    {
        bool isFirstUser = !userManager.Users.Any();

        var user = new ApplicationUser
        {
            UserName = request.Email,
            Email = request.Email,
            FirstName = request.FirstName,
            LastName = request.LastName
        };

        var createResult = await userManager.CreateAsync(user, request.Password);
        if (!createResult.Succeeded)
            return AuthResult.Failure(createResult.Errors.Select(e => e.Description).ToArray());

        if (isFirstUser)
        {
            await EnsureRoleAsync(AdminRole);
            await userManager.AddToRoleAsync(user, AdminRole);
        }

        return AuthResult.Success(await tokenService.CreateTokenAsync(user));
    }

    public async Task<AuthResult> LoginAsync(LoginRequest request)
    {
        var user = await userManager.FindByEmailAsync(request.Email);

        if (user is null || !await userManager.CheckPasswordAsync(user, request.Password))
            return AuthResult.Failure("Invalid email or password.");

        return AuthResult.Success(await tokenService.CreateTokenAsync(user));
    }

    private async Task EnsureRoleAsync(string roleName)
    {
        if (!await roleManager.RoleExistsAsync(roleName))
            await roleManager.CreateAsync(new ApplicationRole { Name = roleName });
    }
}
