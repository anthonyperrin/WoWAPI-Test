using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyWoWApi.WowDtos
{
    [Serializable]
    public class ClassDto
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Nom { get; set; }
    }
}
