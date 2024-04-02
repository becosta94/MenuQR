namespace MenuQR.Application.Entities.DTOs
{
    public class BaseDTO
    {
        public int Id { get; set; }
        public virtual DateTime? CreatedAt { get; set; }
        public virtual DateTime? UpdatedAt { get; set; }



    }
}
