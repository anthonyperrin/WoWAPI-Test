using MyWoWApi;
using MyWoWApi.Auth;
using MyWoWApi.WowDtos;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            var wowService = new WoWApiService();
            var timer = new Stopwatch();
            timer.Start();
            Console.Write("Demande du token d'accès... ");
            AccessToken token = AccessToken.GetToken().Result;
            Console.WriteLine("OK");

            Console.Write("Récupération des classes jouables... ");
            IList<ClassDto> classes = wowService.ClassService.GetClasses();
            Console.WriteLine("OK");

            Console.Write("Récupération des spécialisation jouables... ");
            IList<SpecialisationDto> specs = wowService.SpecialisationService.GetSpecialisations(token);
            Console.WriteLine("OK");
            timer.Stop();
            Console.WriteLine("Opérations réalisées en " + (timer.ElapsedMilliseconds / 1000) + " secondes");
            foreach (var classe in classes)
            {
                Console.WriteLine(classe.Id + " " + classe.Nom + ": ");
                foreach (var spe in specs)
                {
                    if (spe.Classe.Id == classe.Id)
                        Console.WriteLine("    " + spe.Id + " / " + spe.Nom);
                }
            }
            Console.ReadLine();
        }
    }
}
