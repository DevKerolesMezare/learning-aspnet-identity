// Step 1: Core Identity user class with application-specific profile fields.
using Microsoft.AspNetCore.Identity;

namespace IdentitySystem.Domain.Entities;

public sealed class ApplicationUser : IdentityUser
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
}
