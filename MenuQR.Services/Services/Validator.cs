using MenuQR.Services.Interfaces;

namespace MenuQR.Services.Services
{
    public class Validator : IValidator
    {
        object IValidator.Execute(Func<object> func)
        {
            try
            {
                return func();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
