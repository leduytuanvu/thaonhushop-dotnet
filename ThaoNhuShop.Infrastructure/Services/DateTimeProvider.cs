using ThaoNhuShop.Application.Common.Interfaces.Services.DateTimeProvider;

namespace ThaoNhuShop.Infrastructure.Services
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime UtcNow => DateTime.UtcNow;
    }
}