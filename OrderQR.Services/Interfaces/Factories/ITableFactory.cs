using OrderQR.Domain.DTOs;
using OrderQR.Domain.Entities;

namespace OrderQR.Services.Interfaces.Factories
{
    public interface ITableFactory
    {
        public Table Make(TableDTO tableDTO, string userId);
    }
}
