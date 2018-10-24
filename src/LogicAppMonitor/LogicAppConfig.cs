using System;
using System.Collections.Generic;
using System.Text;

namespace LogicAppMonitor
{
    public class LogicAppConfig
    {
        public string WorkflowName { get; set; }
        public string SubscriptionId { get; set; }
        public string ResourceGroupName { get; set; }
        public string TenantId { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }

        private  string _bearerToken = "";
        private  DateTime _tokenExpiration = DateTime.Now.AddDays(-1);

        public string GetCachedBearerToken()
        {
            if (string.IsNullOrEmpty(_bearerToken) || _tokenExpiration < DateTime.Now)
            {
                return null;
            }
            return _bearerToken;
        }

        public void CachedBearerToken(string bearerToken, DateTime tokenExpiration)
        {
            _bearerToken = bearerToken;
            _tokenExpiration = tokenExpiration;
        }
    }
}
