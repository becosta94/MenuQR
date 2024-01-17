using MenuQR.Domain.Entities;
using MenuQR.Services.Interfaces;
using Newtonsoft.Json;

namespace MenuQR.Services.Services
{
    public class NewOrder : INewOrder
    {
        public Order? Make(string orderJson)
        {
            Order? order = JsonConvert.DeserializeObject<Order>(orderJson);
            return order;
        }
    }
}
