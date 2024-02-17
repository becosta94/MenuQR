using AutoMapper;
using MenuQR.Domain.DTOs;
using MenuQR.Domain.Entities;
using MenuQR.Services.Interfaces;
using MenuQR.Services.Interfaces.Factories;
using MenuQR.Services.Validators;

namespace MenuQR.Services.Services.Factories
{
    public class TableFactory : ITableFactory
    {
        private readonly IMapper _mapper;
        private readonly IBaseService<Table> _tableBaseService;
        private readonly IValidator _validator;

        public TableFactory(IMapper mapper, IBaseService<Table> tableBaseService, IValidator validator)
        {
            _mapper = mapper;
            _tableBaseService = tableBaseService;
            _validator = validator;
        }

        public Table Make(TableDTO tableDTO)
        {
            Table? table = _mapper.Map<Table>(tableDTO);
            table = _validator.Execute(() => _tableBaseService.Add<TableValidator>(table)) as Table;
            if (table is not null)
                return table;
            return null;
        }
    }
}
