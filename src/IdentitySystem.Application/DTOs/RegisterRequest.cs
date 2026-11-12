using System.ComponentModel.DataAnnotations;

namespace IdentitySystem.Application.DTOs;

public sealed record RegisterRequest(
    [Required, EmailAddress] string Email,
    [Required] string Password,
    [Required] string FirstName,
    [Required] string LastName);
