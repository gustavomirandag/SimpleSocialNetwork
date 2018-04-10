using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Entities
{
    public class Country
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
        public String Photo { get; set; }
    }
}
