using Auto.Domain.Entities;

namespace Auto.Application.Common.Interfaces.Authentication;

public interface IJwtTokenGenerator 
{
    string GenerateToken(User user);
}