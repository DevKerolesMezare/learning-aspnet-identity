using IdentitySystem.Domain.Entities;

namespace IdentitySystem.Application.Interfaces;

public interface ITokenService
{
    Task<string> CreateTokenAsync(ApplicationUser user);
}
