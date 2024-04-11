using OrderQR.Application.Interfaces;

namespace OrderQR.Application.Entities
{
    public class GenericCommandResult : ICommandResult
    {
        public bool Sucess { get; set; }
        public string? Message { get; set; }
        public object? Data { get; set; }
        public GenericCommandResult() { }
        public GenericCommandResult(bool sucess, string message, object? data)
        {
            Sucess = sucess;
            Message = message;
            Data = data;
        }
    }
}
