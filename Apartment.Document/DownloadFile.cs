using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System.IO;
using System.Web;

namespace Apartment.Document
{
    public class DownloadFile
    {
        public void DownloadPersonFile(List<string> docList)
        {
            try
            {
                //CloudStorageAccount cloudStorageAccount = ConnectionString.GetConnectionString();
                //CloudBlobClient cloudBlobClient = cloudStorageAccount.CreateCloudBlobClient();
                //CloudBlobContainer cloudBlobContainer = cloudBlobClient.GetContainerReference("cadcontainer");

                CloudBlobContainer cloudBlobContainer = Singleton.InstanceCreation.GetblobContainer();

                foreach (string doc in docList)
                {
                    CloudBlockBlob cloudBlockBlob = cloudBlobContainer.GetBlockBlobReference(doc);
                    var imgPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), doc);
                    cloudBlockBlob.DownloadToFile(imgPath, FileMode.OpenOrCreate);
                }
            }

            catch (Exception ex)
            {
                System.Exception.Equals("Exception occured", ex.Message);
            }
        }
    }
}
