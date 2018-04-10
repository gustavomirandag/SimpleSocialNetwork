using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Entities
{
    public class Profile
    {
        public Profile()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
        public String Email { get; set; }
        public String Name { get; set; }
        public int Age { get; set; }
        public String Photo { get; set; }
    }
}
