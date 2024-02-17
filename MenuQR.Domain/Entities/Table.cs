﻿using MenuQR.Domain.Entities;

namespace MenuQR.Domain.Entities
{
    public class Table : BaseEntity
    {
        public string Identification { get; set; }
        public string QRLink { get; set; }
        public virtual Bill Bill { get; set; } = null!;

        public Table(string identification, int companyId)
        {
            Identification = identification;
            CompanyId = companyId;
        }
    }
}
