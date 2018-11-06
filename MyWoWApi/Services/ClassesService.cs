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
    public interface IClassService
    {
        IList<ClassDto> GetClasses();
    }

    public class ClassService : IClassService
    {
        private IWoWApiService WoWApiService;

        public ClassService(IWoWApiService wowapiservice)
        {
            WoWApiService = wowapiservice;
        }

        public IList<ClassDto> GetClasses()
        {
            IList<ClassDto> ta;
            var setting = new JsonSerializerSettings { ContractResolver = new WowApiRootContractResolver("classes") };
            string s;
            using (WebClient client = new WebClient())
            {
                s = client.DownloadString(WoWApiService.UrlFormat("classes"));
                ta = JsonConvert.DeserializeObject<WoWApiJsonRootObject<ClassDto>>(s, setting).Datas.ToList();
            }
            return ta;
        }
    }
}
