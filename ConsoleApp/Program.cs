using Application;
using Data.Context;
using Data.Repositories;
using DomainModel.Entities;
using DomainServices.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Infrastructure - Context
            SocialNetworkContext context = new SocialNetworkContext(); 

            //Infrastructure - Repository
            ProfileRepository profileRepository = new ProfileRepository(context);

            //DomainServices
            ProfileServices profileServices = new ProfileServices(profileRepository);

            //ApplicationServices
            ApplicationServices appServices = new ApplicationServices(profileServices);

            //Seed
            Profile profile1 = new Profile()
            {
                Name = "Samii",
                Age = 20
            };
            Profile profile2 = new Profile()
            {
                Name = "Alexandre",
                Age = 21
            };
            Profile profile3 = new Profile()
            {
                Name = "Wagner",
                Age = 22
            };

            //Chamando o serviço da camada de aplicação
            //para adicionar perfis a rede social
            appServices.AddNewProfile(profile1);
            appServices.AddNewProfile(profile2);
            appServices.AddNewProfile(profile3);

            //Imprimir todos os profiles
            foreach(var p in appServices.GetAllProfiles())
                Console.WriteLine(p.Name);

            Console.ReadLine();
        }
    }
}
