using DomainModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Interfaces.Services
{
    public interface IProfileServices
    {
        void CreateProfile(Profile profile);
        IEnumerable<Profile> GetAllProfiles();

    }
}
