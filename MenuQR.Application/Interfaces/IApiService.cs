using MenuQR.Application.Entities;

namespace MenuQR.Application.Interfaces
{
    public interface IApiService
    {
        public Task<GenericCommandResult> Get<TEntity>(string url);
        public Task<GenericCommandResult> GetById<TEntity>(string url, string jwt, string idParameterName, int id);
        public Task<GenericCommandResult> GetStringById<TEntity>(string url, string jwt, string idParameterName, int id);
        public Task<GenericCommandResult> PostAsJsonAsync<TEntity>(string url, TEntity data);
        public Task<GenericCommandResult> PutWithParameters<TEntity>(string url, Dictionary<string, object> parameterDataPairs);
        public Task<GenericCommandResult> PutAsJsonAsync<TEntity>(string url, TEntity data);
    }
}
