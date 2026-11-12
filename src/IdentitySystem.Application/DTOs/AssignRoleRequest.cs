using System.ComponentModel.DataAnnotations;

namespace IdentitySystem.Application.DTOs;

public sealed record AssignRoleRequest(
    [Required, EmailAddress] string Email,
    [Required] string RoleName);
