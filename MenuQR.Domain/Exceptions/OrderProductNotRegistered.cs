﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuQR.Domain.Exceptions
{
    public class OrderProductNotRegistered : ApplicationException
    {
        public OrderProductNotRegistered(string message) : base(message) { }
    }
}
