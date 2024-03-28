using MenuQR.Application.Entities;
using MenuQR.Application.Interfaces;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace MenuQR.Application.Services
{
    public class ApiService : IApiService
    {
        private readonly HttpClient httpClient;
        public ApiService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        #region Post
        public async Task<GenericCommandResult> PostAsJsonAsync<TEntity>(string url, string jwt, TEntity data)
        {
            try
            {
                if (!string.IsNullOrEmpty(jwt))
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwt);
                var response = await httpClient.PostAsJsonAsync(url, data);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    return new GenericCommandResult(true, "Post made successfully", response);
                else
                    return new GenericCommandResult(false, "Post not made", response);
            }
            catch (Exception ex)
            {
                return new GenericCommandResult(false, "Post not made", ex);
            }
        }
        public async Task<GenericCommandResult> PostWithParameters<TEntity>(string url, string jwt, Dictionary<string, object> parameterDataPairs)
        {
            try
            {
                if (!string.IsNullOrEmpty(jwt))
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwt);
                string parameters = string.Empty;
                int totalParameters = 0;
                foreach (KeyValuePair<string, object> parameterData in parameterDataPairs)
                {
                    if (totalParameters == parameterDataPairs.Count - 1)
                        parameters += $"{parameterData.Key}={parameterData.Value}";
                    else
                    {
                        parameters += $"{parameterData.Key}={parameterData.Value}&";
                        totalParameters++;
                    }
                }
                HttpResponseMessage? response = await httpClient.PostAsync($"{url}{parameters}", null);
                if (response.IsSuccessStatusCode)
                    return new GenericCommandResult(true, "Post made successfully", response);
                else
                    return new GenericCommandResult(false, "Post not made", response);
            }
            catch (Exception ex)
            {
                return new GenericCommandResult(false, "Post not made", ex);
            }
        }
        #endregion

        #region Get
        public async Task<GenericCommandResult> Get<TEntity>(string url, string jwt, int companyId)
        {
            try
            {
                if (!string.IsNullOrEmpty(jwt))
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwt);
                TEntity? response = await httpClient.GetFromJsonAsync<TEntity>(url + companyId);
                if (response is not null)
                    return new GenericCommandResult(true, "Get made successfully", response);
                else
                    return new GenericCommandResult(false, "Get not made", response);
            }
            catch (Exception ex)
            {
                return new GenericCommandResult(false, "Get not made", ex);
            }
        }
        public async Task<GenericCommandResult> GetById<TEntity>(string url, string jwt, string id)
        {
            try
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwt);
                TEntity? response = await httpClient.GetFromJsonAsync<TEntity>($"{url}id={id}");
                if (response is not null)
                    return new GenericCommandResult(true, "Get made successfully", response);
                else
                    return new GenericCommandResult(false, "Get not made", response);
            }
            catch (Exception ex)
            {
                return new GenericCommandResult(false, "Get not made", ex);
            }
        }
        public async Task<GenericCommandResult> GetStringByParameter<TEntity>(string url, string jwt, string parameterName, string parameter)
        {
            try
            {
                if (!string.IsNullOrEmpty(jwt))
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwt);
                string response = httpClient.GetStringAsync($"{url}{parameterName}={parameter}").Result;
                if (!response.IsNullOrEmpty())
                    return new GenericCommandResult(true, "Get made successfully", response);
                else
                    return new GenericCommandResult(false, "Get not made", response);
            }
            catch (Exception ex)
            {
                return new GenericCommandResult(false, "Get not made", ex);
            }
        }
        public async Task<GenericCommandResult> GetWithParameters<TEntity>(string url, string jwt, Dictionary<string, object> parameterDataPairs)
        {
            try
            {
                if (!string.IsNullOrEmpty(jwt))
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwt);
                string parameters = string.Empty;
                int totalParameters = 0;
                foreach (KeyValuePair<string, object> parameterData in parameterDataPairs)
                {
                    if (totalParameters == parameterDataPairs.Count - 1)
                        parameters += $"{parameterData.Key}={parameterData.Value}";
                    else
                    {
                        parameters += $"{parameterData.Key}={parameterData.Value}&";
                        totalParameters++;
                    }
                }
                TEntity? response = await httpClient.GetFromJsonAsync<TEntity>($"{url}{parameters}");
                if (response is not null)
                    return new GenericCommandResult(true, "Post made successfully", response);
                else
                    return new GenericCommandResult(false, "Post not made", response);
            }
            catch (Exception ex)
            {
                return new GenericCommandResult(false, "Post not made", ex);
            }
        }

        #endregion

        #region Put
        public async Task<GenericCommandResult> PutWithParameters<TEntity>(string url, string jwt, Dictionary<string, object> parameterDataPairs)
        {
            try
            {
                if (!string.IsNullOrEmpty(jwt))
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwt);
                string parameters = string.Empty;
                int totalParameters = 0;
                foreach (KeyValuePair<string, object> parameterData in parameterDataPairs)
                {
                    if (totalParameters == parameterDataPairs.Count - 1)
                        parameters += $"{parameterData.Key}={parameterData.Value}";
                    else
                    {
                        parameters += $"{parameterData.Key}={parameterData.Value}&";
                        totalParameters++;
                    }
                }
                HttpResponseMessage? response = await httpClient.PutAsync($"{url}{parameters}", null);
                if (response.IsSuccessStatusCode)
                    return new GenericCommandResult(true, "Put made successfully", response);
                else
                    return new GenericCommandResult(false, "Put not made", response);
            }
            catch (Exception ex)
            {
                return new GenericCommandResult(false, "Put not made", ex);
            }
        }
        public async Task<GenericCommandResult> PutAsJsonAsync<TEntity>(string url, string jwt, TEntity data)
        {
            try
            {
                if (!string.IsNullOrEmpty(jwt))
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwt);
                var response = await httpClient.PutAsJsonAsync(url, data);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    return new GenericCommandResult(true, "Put made successfully", response);
                else
                    return new GenericCommandResult(false, "Put not made", response);
            }
            catch (Exception ex)
            {
                return new GenericCommandResult(false, "Post not made", ex);
            }
        }
        #endregion

        public static StringContent PrepareStringContent(object obj)
        {
            return new(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");
        }
    }
}