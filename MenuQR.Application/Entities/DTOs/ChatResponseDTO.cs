namespace MenuQR.Application.Entities.DTOs
{
    public class ChatResponseDTO : BaseDTO
    {
        public string? Response { get; set; }
        public List<string>? Menssage { get; set; } = new List<string>();
    }
}
