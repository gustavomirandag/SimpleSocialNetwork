using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;

namespace StorageService
{
    public class Common
    {
        public static CloudStorageAccount GetStorageAccount()
        {
            return CloudStorageAccount.Parse(StorageService.Properties.Settings.Default.StorageConnectionString);
        }
    }
}
