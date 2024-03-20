using MenuQR.Services.Interfaces;
using Newtonsoft.Json;
using System.IO;
using System.Net;
using System.Text.Json.Nodes;

namespace MenuQR.Services.Services
{
    public class CpfValidatorService : ICpfValidatorService
    {
        public bool Validate(string cpf)
        {
            cpf = cpf.Replace(".", "").Replace("-", "");
            string url = "https://api.invertexto.com/v1/validator?token=6976%7Cx68uLD6VQuTVLvzqS8aDBQop1MuVJVat&value=" + cpf + "&type=cpf";
            WebRequest wrGETURL;
            wrGETURL = WebRequest.Create(url);
            Stream objStream;
            objStream = wrGETURL.GetResponse().GetResponseStream();
            string response = string.Empty;
            using (StreamReader reader = new StreamReader(objStream))
            {
                response = reader.ReadToEnd();
            }
            Dictionary<string, string>? apiResponse = JsonConvert.DeserializeObject<Dictionary<string, string>>(response);
            if (apiResponse is null)
                return false;
            KeyValuePair<string, string> keyValuePair = apiResponse.Where(x => x.Key == "valid").First();
            if (keyValuePair.Value.ToString() == "false")
                return false;
            return true;
        }
    }
}
