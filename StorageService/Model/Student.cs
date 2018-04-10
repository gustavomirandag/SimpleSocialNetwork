using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageService.Model
{
    public class Student : TableEntity
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
        public int Age { get; set; }
    }
}
