// Step 1: Core Identity role class with an application-specific description.
using Microsoft.AspNetCore.Identity;

namespace IdentitySystem.Domain.Entities;

public sealed class ApplicationRole : IdentityRole
{
    public string? Description { get; set; }
}
