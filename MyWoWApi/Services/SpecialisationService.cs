using MyWoWApi.Auth;
using MyWoWApi.Utils;
using MyWoWApi.WowDtos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;

namespace MyWoWApi.Services
{
    public interface ISpecialisationService
    {
        IList<SpecialisationDto> GetSpecialisations(AccessToken token);
        SpecialisationDto GetSpecialisation(AccessToken token, string Id);
    }

    public class SpecialisationService : ISpecialisationService
    {
        private IWoWApiService WoWApiService;

        public SpecialisationService(IWoWApiService wowapiservice)
        {
            WoWApiService = wowapiservice;
        }

        public IList<SpecialisationDto> GetSpecialisations(AccessToken token)
        {
            var setting = new JsonSerializerSettings { ContractResolver = new WowApiRootContractResolver("character_specializations") };
            using (WebClient client = new WebClient())
            {
                var s = client.DownloadString(String.Format("https://eu.api.battle.net/data/wow/playable-specialization/?namespace=static-eu&locale=en_GB&access_token={0}", token.Access_token));
                IList<SpecialisationDto> specs = JsonConvert.DeserializeObject<WoWApiJsonRootObject<SpecialisationDto>>(s, setting).Datas.ToList();
                foreach (var spec in specs.ToList())
                {
                    var index = specs.IndexOf(spec);
                    var nspec = GetSpecialisation(token, spec.Id);
                    specs[index] = nspec;
                }
                return specs;

            }
        }

        public SpecialisationDto GetSpecialisation(AccessToken token, string Id)
        {
            using (WebClient client = new WebClient())
            {
                var s = client.DownloadString(String.Format("https://eu.api.battle.net/data/wow/playable-specialization/{0}?namespace=static-eu&locale=en_GB&access_token={1}", Int32.Parse(Id), token.Access_token));
                SpecialisationDto p = JsonConvert.DeserializeObject<SpecialisationDto>(s);
                return p;
            }
        }

    }
}
