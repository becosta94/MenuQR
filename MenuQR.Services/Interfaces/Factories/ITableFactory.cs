using MenuQR.Domain.DTOs;
using MenuQR.Domain.Entities;

namespace MenuQR.Services.Interfaces.Factories
{
    public interface ITableFactory
    {
        public Table Make(TableDTO tableDTO);
    }
}
