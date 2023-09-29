namespace Ticket360.Application.Identity.Tokens;

public record RefreshTokenRequest(string Token, string RefreshToken);