using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace Apartment.Document
{
    /// <summary>
    /// The Singleton class
    /// </summary>
    public class Singleton
    {
        private static Singleton instance =null;
        private Singleton()
        {
            
        }

        private static object synLock = new object();
        public static Singleton InstanceCreation
        {
            get
            {
            lock(synLock)
                {
                    if (instance == null)
                        instance = new Singleton();

                    return instance;
                }

            }
        }

        public CloudBlobContainer GetblobContainer()
        {
            CloudStorageAccount cloudStorageAccount = ConnectionString.GetConnectionString();
            CloudBlobClient cloudBlobClient = cloudStorageAccount.CreateCloudBlobClient();
            CloudBlobContainer cloudBlobContainer = cloudBlobClient.GetContainerReference("cadcontainer");

            return cloudBlobContainer;
        }
    }

}
