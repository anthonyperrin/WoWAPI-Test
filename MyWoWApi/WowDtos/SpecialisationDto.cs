using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace MyWoWApi.WowDtos
{
    [Serializable]
    public class SpecialisationDto
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Nom { get; set; }
        [JsonProperty(PropertyName = "playable_class")]
        public ClassDto Classe { get; set; }
        [JsonProperty(PropertyName = "")]
        public string Role {get; set;}
    }
}
