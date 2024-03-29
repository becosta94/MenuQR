﻿namespace MenuQR.Application.Entities.DTOs
{
    public class TableDTO : BaseDTOCompanyId
    {
        public string Identification { get; set; }
        public Guid Unique { get; set; }
        public string QRLink { get; set; }
    }
}
