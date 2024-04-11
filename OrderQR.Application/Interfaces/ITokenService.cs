namespace OrderQR.Application.Interfaces
{
    public interface ITokenService
    {
        public string GenerateToken(string UserEmail);
    }
}
