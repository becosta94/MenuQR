using OrderQR.Application.Data;

namespace OrderQR.Application.Interfaces
{
    public interface IUserGetter
    {
        public Task<ApplicationUser> Get();
    }
}
