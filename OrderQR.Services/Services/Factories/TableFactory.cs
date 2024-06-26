﻿using AutoMapper;
using OrderQR.Domain.DTOs;
using OrderQR.Domain.Entities;
using OrderQR.Services.Interfaces;
using OrderQR.Services.Interfaces.Factories;
using OrderQR.Services.Validators;
using Microsoft.Extensions.Configuration;

namespace OrderQR.Services.Services.Factories
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

        public Table Make(TableDTO tableDTO, string userId)
        {
            Table? table = _mapper.Map<Table>(tableDTO);
            table.Unique = Guid.NewGuid();
            table = _validator.Execute(() => _tableBaseService.Add<TableValidator>(table, table.CompanyId, userId)) as Table;
            table.Link = _configuration["ApplicationLink"].ToString() + $"{table.CompanyId}/{table.Id}/customer/login/";
            table = _validator.Execute(() => _tableBaseService.Update<TableValidator>(table, table.CompanyId, userId)) as Table;
            if (table is not null)
                return table;
            return null;
        }
    }
}
