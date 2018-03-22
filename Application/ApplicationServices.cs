using DomainModel.Entities;
using DomainModel.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    //Disponibilizar todos os serviços do nosso Domínio.
    public class ApplicationServices
    {
        //Serviço de Domínio
        private IProfileServices _profileServices;

        public ApplicationServices(IProfileServices profileServices)
        {
            _profileServices = profileServices;
        }

        //########### Serviços de Perfil #############
        public void AddNewProfile(Profile profile)
        {
            _profileServices.CreateProfile(profile);
        }
        public IEnumerable<Profile> GetAllProfiles()
        {
            return _profileServices.GetAllProfiles();
        }
        //############################################

    }
}
