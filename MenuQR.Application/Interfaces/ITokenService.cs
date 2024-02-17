using MenuQR.Domain.Entities;

namespace MenuQR.Application.Interfaces
{
    public interface ITokenService
    {
        public string GenerateToken(string UserEmail);
    }
}
