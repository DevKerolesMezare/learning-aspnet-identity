using System.ComponentModel.DataAnnotations;

namespace IdentitySystem.Application.DTOs;

public sealed record LoginRequest(
    [Required, EmailAddress] string Email,
    [Required] string Password);
