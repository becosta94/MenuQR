namespace OrderQR.Application.Entities.DTOs
{
    public class TableDTO : BaseDTOCompanyId
    {
        public string Identification { get; set; }
        public Guid Unique { get; set; }
        public string Link { get; set; }
    }
}
