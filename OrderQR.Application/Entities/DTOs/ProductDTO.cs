using System.ComponentModel.DataAnnotations;

namespace OrderQR.Application.Entities.DTOs
{
    public class ProductDTO : BaseDTOCompanyId
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [StringLength(400)]
        public string? Description { get; set; }
        [Required]
        [Range(1.00, double.MaxValue)]
        public double Price { get; set; }
        [Required]
        [Range(1.00, double.MaxValue)]
        public double Cost { get; set; }
        public string? Image { get; set; }
        [Required]
        public bool Active { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int ProductTypeId { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int ProductTypeCompanyId { get; set; }

    }
}
