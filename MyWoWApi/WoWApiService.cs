using MyWoWApi.Auth;
using MyWoWApi.Services;
using System;


namespace MyWoWApi
{
    public interface IWoWApiService
    {
        IClassService ClassService { get; set; }
        IPersonnageService PersonnageService { get; set; }

        ISpecialisationService SpecialisationService { get; set; }
        string UrlFormat(string p);
    }
    public class WoWApiService : IWoWApiService
    {
        private static readonly string API_KEY = "53kj82tbrepw58rm3vzpmajrqbtet3p5";

        public IClassService ClassService { get; set; }
        public IPersonnageService PersonnageService { get; set; }

        public ISpecialisationService SpecialisationService { get; set; }

        public WoWApiService()
        {
            ClassService = new ClassService(this);
            PersonnageService = new PersonnageService(this);
            SpecialisationService = new SpecialisationService(this);
        }

        public string UrlFormat(string p)
        {
            return String.Format("https://eu.api.battle.net/wow/data/character/{0}?locale=en_US&apikey={1}", p, API_KEY);
        }
    }
}



