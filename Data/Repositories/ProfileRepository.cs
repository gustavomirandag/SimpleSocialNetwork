using DomainModel.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel.Entities;
using Data.Context;
using System.Data.Entity;

namespace Data.Repositories
{
    public class ProfileRepository : IProfileRepository
    {
        private SocialNetworkContext _socialNetworkContext;
        private DbSet<Profile> _dbSet;

        public ProfileRepository(SocialNetworkContext socialNetworkContext)
        {
            _socialNetworkContext = socialNetworkContext;
            _dbSet = socialNetworkContext.Set<Profile>();
        }

        public void Add(Profile profile)
        {
            _dbSet.Add(profile);
            _socialNetworkContext.SaveChanges();
        }

        public IEnumerable<Profile> GetAll()
        {
            return _dbSet;
        }
    }
}
