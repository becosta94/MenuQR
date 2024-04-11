namespace OrderQR.Domain.DTOs
{
    public class ErroDTO
    {
        public string Menssage { get; set; }

        public ErroDTO(string menssage)
        {
            Menssage = menssage;
        }
    }    

}
