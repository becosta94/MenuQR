using MenuQR.Domain.Entities;

namespace MenuQR.Domain.Entities
{
    public class Costumer : BaseEntity
    {
        public string Name { get; set; }
        public string MacAdress { get; set; }
        public string Document { get; set; }
        public bool IsOnPlace { get; set; }
        public Costumer(int companyId)
        {
            IsOnPlace = true;
            CompanyId = companyId;
        }
    }
}
