using Newtonsoft.Json;
using System.Text;

namespace MenuQR.Application.Services
{
    public class ApiService
    {
        private readonly HttpClient httpClient;

        public ApiService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public static StringContent PrepareStringContent(object obj)
        {
            return new(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");
        }

        public async Task<bool> DeleteProblem(Guid problemid)
        {
            using (HttpResponseMessage responseMessage = await httpClient.DeleteAsync($"api/admin/deleteproblem/{problemid}"))
            {
                return responseMessage.IsSuccessStatusCode;

            }
        }
    }
}