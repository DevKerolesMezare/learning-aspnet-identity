namespace IdentitySystem.Application.Results;

public sealed record AuthResult(bool Succeeded, string? Token, string[] Errors)
{
    public static AuthResult Success(string? token = null) => new(true, token, []);
    public static AuthResult Failure(params string[] errors) => new(false, null, errors);
}
