using IdentitySystem.Application.DTOs;
using IdentitySystem.Application.Results;
using IdentitySystem.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace IdentitySystem.Infrastructure.Services.Auth;

public class RoleAuthService(
    UserManager<ApplicationUser> userManager,
    RoleManager<ApplicationRole> roleManager)
{
    public async Task<AuthResult> AssignRoleAsync(AssignRoleRequest request)
    {
        var user = await userManager.FindByEmailAsync(request.Email);
        if (user is null)
            return AuthResult.Failure("User was not found.");

        var roleName = request.RoleName.Trim();
        if (string.IsNullOrWhiteSpace(roleName))
            return AuthResult.Failure("Role name is required.");

        await EnsureRoleAsync(roleName);

        if (await userManager.IsInRoleAsync(user, roleName))
            return AuthResult.Success();

        var assignResult = await userManager.AddToRoleAsync(user, roleName);
        return assignResult.Succeeded
            ? AuthResult.Success()
            : AuthResult.Failure(assignResult.Errors.Select(e => e.Description).ToArray());
    }

    private async Task EnsureRoleAsync(string roleName)
    {
        if (!await roleManager.RoleExistsAsync(roleName))
            await roleManager.CreateAsync(new ApplicationRole { Name = roleName });
    }
}
