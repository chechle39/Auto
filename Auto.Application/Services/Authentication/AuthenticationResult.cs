using Auto.Domain.Entities;

namespace Auto.Application.Services.Authentication;

public record AuthenticationResult(
    User user,
    string Token
);