namespace MenuQR.Services.Interfaces
{
    public interface IValidator
    {
        public object Execute(Func<object> func);
    }
}
