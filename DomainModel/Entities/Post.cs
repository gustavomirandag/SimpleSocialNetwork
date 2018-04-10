using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Entities
{
    public class Post
    {
        public Guid Id { get; set; }
        public String Content { get; set; }
        public virtual Profile Author { get; set; }
    }
}
