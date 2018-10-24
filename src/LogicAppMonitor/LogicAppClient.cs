using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace LogicAppMonitor
{
    public class LogicAppClient
    {
        private async Task CheckAuthentication(LogicAppConfig config)
        {
            if (config.GetCachedBearerToken() != null)
            {
                // Current bearer token is still valid
                return;
            }

            var oAuthUri = $"https://login.microsoftonline.com/{config.TenantId}/oauth2/token";
            var response = await oAuthUri
                .WithHeader("Cache-Control", "no-cache")
                .WithHeader("Content-Type", "application/x-www-form-urlencoded")
                .PostUrlEncodedAsync(
                    new
                    {
                        grant_type = "client_credentials",
                        client_id = config.ClientId,
                        client_secret = config.ClientSecret,
                        resource = "https://management.azure.com/"
                    });

            if(!response.IsSuccessStatusCode)
            {
                throw new Exception($"Request failed.({(response.Content)})");
            }
            var authResponse = JObject.Parse(await response.Content.ReadAsStringAsync());
            var tokenExpiration = DateTime.Now.AddSeconds(authResponse["expires_in"].Value<int>());
            var bearerToken = authResponse["access_token"].Value<string>();
            config.CachedBearerToken(bearerToken, tokenExpiration);
        }

        public async Task<string> Execute(string apiPath, IDictionary<string, object> queryParams, LogicAppConfig config)
        {
            await CheckAuthentication(config);
            string dateString = DateTime.Now.AddDays(2).ToString("yyyy-MM-dd");

            string baseUri =$"https://management.azure.com/subscriptions/{config.SubscriptionId}/resourceGroups/{config.ResourceGroupName}/providers/Microsoft.Logic/workflows/{config.WorkflowName}";

            var url = baseUri.AppendPathSegment(apiPath)
                .SetQueryParam("api-version", "2016-06-01")
                .SetQueryParams(queryParams);
            Console.WriteLine(url);
            return await url
                .WithHeader("Cache-Control", "no-cache")
                .WithHeader("Content-Type", "application/json")
                .WithOAuthBearerToken(config.GetCachedBearerToken())
                .GetStringAsync();
        }
    }
}
