using MauimyApp3.Models.Response;
using MauimyApp3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MauiApiIntegration.Services
{
    public class LoginService : ILoginRepository
    {
        public async Task<bool> Login(string userName, string password)
        {
            var login = new UserInfo()
            {
                EmailId = userName,
                Password = password
            };
            var httpClient = new HttpClient();
            var json = JsonConvert.SerializeObject(login);
            var postData = await StreamContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("https://papercareapi.azurewebsites.net/api/Account/authenticate", postData);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var details = JsonConvert.SerializeObject(JObject.Parse(jsonResponse)["Data"]);

                var Data = JsonConvert.DeserializeObject<AuthResponse>(details);

                var tokentext = Data.jwtToken;
                Preferences.Set("TokenKey", tokentext);

                var usertext = Data.emailId;
                Preferences.Set("EmailKey", usertext);

                return true;
            }
            return false;
        }
    }
}
