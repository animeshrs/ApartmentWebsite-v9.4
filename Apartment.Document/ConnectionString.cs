using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using System.Configuration;

namespace Apartment.Document
{
    public static class ConnectionString
    {
        static string account = "cadgroup6";
        static string key = "DhjihntPyZ7/fy1L29PLSqFdYr1YDIWghXaBnfDEst+YGXZI+OMfGdnbRNY700tL/heiSpenZu+Olm/IfYzKPg==";

        public static CloudStorageAccount GetConnectionString ()
        {
            string connectionString = string.Format("DefaultEndpointsProtocol=https;AccountName={0};AccountKey={1}", account, key);
            return CloudStorageAccount.Parse(connectionString);
        }

        public static string connectionString()
        {
            return ConfigurationManager.ConnectionStrings["ApartmentDBContext"].ConnectionString;
        }
    }
}
