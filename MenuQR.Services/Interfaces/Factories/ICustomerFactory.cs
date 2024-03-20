﻿using MenuQR.Domain.DTOs;
using MenuQR.Domain.Entities;

namespace MenuQR.Services.Interfaces.Factories
{
    public interface ICustomerFactory
    {
        public object Make(CustomerDTO customerDTO);
    }
}
