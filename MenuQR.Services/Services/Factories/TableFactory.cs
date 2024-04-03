using AutoMapper;
using MenuQR.Domain.DTOs;
using MenuQR.Domain.Entities;
using MenuQR.Services.Interfaces;
using MenuQR.Services.Interfaces.Factories;
using MenuQR.Services.Validators;
using Microsoft.Extensions.Configuration;

namespace MenuQR.Services.Services.Factories
{
    public class TableFactory : ITableFactory
    {
        private readonly IMapper _mapper;
        private readonly IBaseService<Table> _tableBaseService;
        private readonly IValidator _validator;
        private readonly IConfiguration _configuration;

        public TableFactory(IMapper mapper, IBaseService<Table> tableBaseService, IValidator validator, IConfiguration configuration)
        {
            _mapper = mapper;
            _tableBaseService = tableBaseService;
            _validator = validator;
            _configuration = configuration;
        }

        public Table Make(TableDTO tableDTO)
        {
            Table? table = _mapper.Map<Table>(tableDTO);
            table.Unique = Guid.NewGuid();
            table = _validator.Execute(() => _tableBaseService.Add<TableValidator>(table)) as Table;
            table.Link = _configuration["ApplicationLink"].ToString() + $"{table.CompanyId}/{table.Id}/customer/login/";
            table = _validator.Execute(() => _tableBaseService.Update<TableValidator>(table)) as Table;
            if (table is not null)
                return table;
            return null;
        }
    }
}
