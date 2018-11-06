using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MyWoWApi.Auth
{
    public class AccessToken
    {
        public string Access_token { get; set; }
        public string Token_type { get; set; }
        public long Expires_in { get; set; }

        public static async Task<AccessToken> GetToken()
        {
            string clientId = "53kj82tbrepw58rm3vzpmajrqbtet3p5";
            string clientSecret = "5MxAMweeaDDAjuNXNVmBkdC4m6KmBV9y";
            string credentials = String.Format("{0}:{1}", clientId, clientSecret);
            string apiId = "11570";

            using (var client = new HttpClient())
            {
                //Define Headers
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes(credentials)));

                //Prepare Request Body
                List<KeyValuePair<string, string>> requestData = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("grant_type", "client_credentials"),
                    new KeyValuePair<string, string>("apiId", apiId),
                    new KeyValuePair<string, string>("client_id", clientId),
                    new KeyValuePair<string, string>("client_secret", clientSecret)
                };

                FormUrlEncodedContent requestBody = new FormUrlEncodedContent(requestData);

                //Request Token
                var request = await client.PostAsync("https://us.battle.net/oauth/token?", requestBody);
                var response = await request.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<AccessToken>(response);
            }
        }
    }
}
