using MenuQR.Application.Entities;
using System.Net.Http.Headers;
using System.Net.Http;

namespace MenuQR.Application.Interfaces
{
    public interface IApiService
    {
        public Task<GenericCommandResult> Get<TEntity>(string url, string jwt, int companyId);
        public Task<GenericCommandResult> GetById<TEntity>(string url, string jwt, string id);
        public Task<GenericCommandResult> GetStringByParameter<TEntity>(string url, string jwt, string parameterName, string id);
        public Task<GenericCommandResult> GetWithParameters<TEntity>(string url, string jwt, Dictionary<string, object> parameterDataPairs);
        public Task<GenericCommandResult> PostAsJsonAsync<TEntity>(string url, string jwt, TEntity data);
        public Task<GenericCommandResult> PostWithParameters<TEntity>(string url, string jwt, Dictionary<string, object> parameterDataPairs);
        public Task<GenericCommandResult> PutWithParameters<TEntity>(string url, string jwt, Dictionary<string, object> parameterDataPairs);
        public Task<GenericCommandResult> PutAsJsonAsync<TEntity>(string url, string jwt, TEntity data);
        public Task<GenericCommandResult> DeleteWithParameters<TEntity>(string url, string jwt, Dictionary<string, object> parameterDataPairs);
    }
}
