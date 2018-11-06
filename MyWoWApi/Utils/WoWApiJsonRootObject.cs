using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyWoWApi.Utils
{ 
    public class WowApiRootContractResolver : DefaultContractResolver
    {
        private Dictionary<string, string> PropertyMappings { get; set; }

        public WowApiRootContractResolver(String rootName)
        {
            this.PropertyMappings = new Dictionary<string, string>
                {
                    {"Root", rootName},
                };
        }

        protected override string ResolvePropertyName(string propertyName)
        {
            string resolvedName = null;
            var resolved = this.PropertyMappings.TryGetValue(propertyName, out resolvedName);
            return (resolved) ? resolvedName : base.ResolvePropertyName(propertyName);
        }
    }

    [Serializable]
    public class WoWApiJsonRootObject<T>
    {
        [JsonProperty(PropertyName = "Root")]
        public IEnumerable<T> Datas { get; set; }
    }
}
