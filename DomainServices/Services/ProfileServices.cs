using DomainModel.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel.Entities;
using DomainModel.Interfaces.Repositories;

namespace DomainServices.Services
{
    //ProfileServices é a classe que fornece serviços de domínio
    //para ela poder Criar Perfis e retornar Todos os Perfis armazenados
    //ela obviamente precisa ter acesso ao repositório de perfis.
    public class ProfileServices : IProfileServices
    {
        //Atributo privado da classe de serviços.
        //Ele armazena uma referência ao repositório de perfis.
        private IProfileRepository _profileRepository;

        public ProfileServices(IProfileRepository profileRepository)
        {
            _profileRepository = profileRepository;
        }

        /// <summary>
        /// Serviço que permite um novo perfil no repositório.
        /// </summary>
        /// <param name="profile">Perfil a ser adicionado ao repositório.</param>
        public void CreateProfile(Profile profile)
        {
            _profileRepository.Add(profile);
        }

        /// <summary>
        /// Serviço de perfil que retorna todos os perfis do repositório.
        /// </summary>
        /// <returns>Retorna uma lista de perfis.</returns>
        public IEnumerable<Profile> GetAllProfiles()
        {
            return _profileRepository.GetAll();
        }
    }
}
