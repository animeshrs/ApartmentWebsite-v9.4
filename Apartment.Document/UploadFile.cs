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
    public class UploadFile
    {
        public async Task<string> UploadPersonFile(HttpPostedFileBase imageToUpload)
        {
            string imageFullPath = string.Empty; string imageName = string.Empty;
            try
            {
                //CloudStorageAccount cloudStorageAccount = ConnectionString.GetConnectionString();
                //CloudBlobClient cloudBlobClient = cloudStorageAccount.CreateCloudBlobClient();
                //CloudBlobContainer cloudBlobContainer = cloudBlobClient.GetContainerReference("cadcontainer");
                CloudBlobContainer cloudBlobContainer = Singleton.InstanceCreation.GetblobContainer();
                if (await cloudBlobContainer.CreateIfNotExistsAsync())
                {
                    await cloudBlobContainer.SetPermissionsAsync(
                        new BlobContainerPermissions
                        {
                            PublicAccess = BlobContainerPublicAccessType.Blob
                        }
                        );
                }
                imageName = imageToUpload.FileName;//Path.GetExtension(imageToUpload.FileName);

                CloudBlockBlob cloudBlockBlob = cloudBlobContainer.GetBlockBlobReference(imageName);
                cloudBlockBlob.Properties.ContentType = imageToUpload.ContentType;
                await cloudBlockBlob.UploadFromStreamAsync(imageToUpload.InputStream);

                //imageFullPath = cloudBlockBlob.Uri.ToString();

            }

            catch (Exception ex)
            {
                System.Exception.Equals("Exception occured", ex.Message);
            }
            return imageName;
        }
        public string UploadPersonDoc(HttpPostedFileBase imageToUpload)
        {
            string imageFullPath = string.Empty; string imageName = string.Empty;
            try
            {
                CloudBlobContainer cloudBlobContainer = Singleton.InstanceCreation.GetblobContainer();
                imageName = imageToUpload.FileName;//Path.GetExtension(imageToUpload.FileName);

                CloudBlockBlob cloudBlockBlob = cloudBlobContainer.GetBlockBlobReference(imageName);
                cloudBlockBlob.Properties.ContentType = imageToUpload.ContentType;
                cloudBlockBlob.UploadFromStream(imageToUpload.InputStream);

                //imageFullPath = cloudBlockBlob.Uri.ToString();

            }

            catch (Exception ex)
            {
                System.Exception.Equals("Exception occured", ex.Message);
            }
            return imageName;
        }
    }
}
