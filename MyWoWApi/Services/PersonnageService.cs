using MyWoWApi.Utils;
using MyWoWApi.WowDtos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace MyWoWApi.Services
{
    public interface IPersonnageService
    {
        PersonnageDto GetPersonnage(string realm, string cName);
    }

    public class PersonnageService : IPersonnageService
    {
        private IWoWApiService WoWApiService;

        public PersonnageService(IWoWApiService wowapiservice)
        {
            WoWApiService = wowapiservice;
        }

        public PersonnageDto GetPersonnage(string realm, string cName)
        {
            using (WebClient client = new WebClient())
            {
                var s = client.DownloadString(String.Format("https://eu.api.battle.net/wow/character/{0}/{1}?locale=fr_FR&apikey=53kj82tbrepw58rm3vzpmajrqbtet3p5", realm, cName));
                PersonnageDto p = JsonConvert.DeserializeObject<PersonnageDto>(s);
                return p;
            }
        }
    }
}
