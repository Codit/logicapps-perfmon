using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace ReportGenerator
{
    public class LogicAppsDataSection : ConfigurationSection
    {
        /// <summary>
        /// The name of this section in the app.config.
        /// </summary>
        public const string SectionName = "LogicAppsDataSection";

        private const string EndpointCollectionName = "LogicAppsEndpoints";

        [ConfigurationProperty(EndpointCollectionName)]
        [ConfigurationCollection(typeof(LogicAppsEndpointsCollection), AddItemName = "add")]
        public LogicAppsEndpointsCollection LogicAppsEndpoints => (LogicAppsEndpointsCollection)base[EndpointCollectionName];
    }

    public class LogicAppsEndpointsCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new LogicAppsEndpointElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((LogicAppsEndpointElement)element).Name;
        }
    }

    public class LogicAppsEndpointElement : ConfigurationElement
    {
        [ConfigurationProperty("name", IsRequired = true, IsKey = true)]
        public string Name
        {
            get => (string)this["name"];
            set => this["name"] = value;
        }
        [ConfigurationProperty("workflowname", IsRequired = true)]
        public string WorkflowName
        {
            get => (string)this["workflowname"];
            set => this["workflowname"] = value;
        }

        [ConfigurationProperty("resourcegroup", IsRequired = true)]
        public string ResourceGroup
        {
            get => (string)this["resourcegroup"];
            set => this["resourcegroup"] = value;
        }

        [ConfigurationProperty("subscriptionid", IsRequired = true)]
        public string SubscriptionId
        {
            get => (string)this["subscriptionid"];
            set => this["subscriptionid"] = value;
        }
        [ConfigurationProperty("tenantid", IsRequired = true)]
        public string TenantId
        {
            get => (string)this["tenantid"];
            set => this["tenantid"] = value;
        }
        [ConfigurationProperty("clientid", IsRequired = true)]
        public string ClientId
        {
            get => (string)this["clientid"];
            set => this["clientid"] = value;
        }

        [ConfigurationProperty("clientsecret", IsRequired = true)]
        public string ClientSecret
        {
            get => (string)this["clientsecret"];
            set => this["clientsecret"] = value;
        }
    }


}
