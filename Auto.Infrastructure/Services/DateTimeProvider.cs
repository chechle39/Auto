using Auto.Application.Common.Interfaces.Services;

namespace Auto.Infrastructure.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.Now;
}