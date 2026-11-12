// Steps 3 and 5: Register SQL Server Identity persistence and auth services.
using IdentitySystem.Application.Interfaces;
using IdentitySystem.Domain.Entities;
using IdentitySystem.Infrastructure.Persistence;
using IdentitySystem.Infrastructure.Services.Auth;
using IdentitySystem.Infrastructure.Services.Token;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration; // 👈 ضيفنا دي
using Microsoft.Extensions.DependencyInjection;

namespace IdentitySystem.Infrastructure;

public static class DependencyInjection
{
    // 👈 ضيفنا IConfiguration عشان نقرأ الـ Connection String
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlite(
                config.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)
            ));

        services.AddIdentityCore<ApplicationUser>(options =>
                options.User.RequireUniqueEmail = true)
            .AddRoles<ApplicationRole>()
            .AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders();

        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<UserAuthService>();
        services.AddScoped<RoleAuthService>();
        services.AddScoped<IAuthService, AuthFacade>();

        return services;
    }
}