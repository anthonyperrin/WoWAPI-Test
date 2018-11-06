using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyWoWApi.WowDtos
{
    [Serializable]
    public class PersonnageDto
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Nom { get; set; }
        [JsonProperty(PropertyName = "realm")]
        public string Serveur { get; set; }
        [JsonProperty(PropertyName = "class")]
        public string ClassId { get; set; }
        [JsonProperty(PropertyName = "race")]
        public string RaceId { get; set; }
        [JsonProperty(PropertyName = "thumbnail")]
        public string Portait { get; set; }
        [JsonProperty(PropertyName = "faction")]
        public string Faction { get; set; }
    }
}
