namespace Ticket360.Application.Identity.Tokens;

public record TokenResponse(string Token, string RefreshToken, DateTime RefreshTokenExpiryTime);