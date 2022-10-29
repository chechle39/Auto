using Auto.Domain.Entities;

namespace Auto.Application.Services.Authentication.Common;

public record AuthenticationResult(
    User user,
    string Token
);