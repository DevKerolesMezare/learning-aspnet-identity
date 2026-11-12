// Steps 7-8: JWT auth endpoints; Admin role authorization protects role assignment.
using IdentitySystem.Application.DTOs;
using IdentitySystem.Application.Interfaces;
using IdentitySystem.Application.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IdentitySystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class AuthController(IAuthService authService) : ControllerBase
{
    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var result = await authService.RegisterAsync(request);
        return result.Succeeded
            ? Ok(new { result.Token })
            : BadRequest(new { result.Errors });
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var result = await authService.LoginAsync(request);
        return result.Succeeded
            ? Ok(new { result.Token })
            : Unauthorized(new { result.Errors });
    }

    [Authorize(Roles = "Admin")]
    [HttpPost("assign-role")]
    public async Task<IActionResult> AssignRole(AssignRoleRequest request)
    {
        var result = await authService.AssignRoleAsync(request);
        return result.Succeeded
            ? Ok(new { message = "Role assigned." })
            : BadRequest(new { result.Errors });
    }
}
