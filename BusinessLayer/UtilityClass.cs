using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Web.Security;
using System.Security.Cryptography;

namespace ApartmentBusinessLayer
{
    public class UtilityClass
    {
        //This method is used for parameters which are nullable and have no user value input 
        public static string IsNullable(string stringValue)
        {
            if (string.IsNullOrEmpty(stringValue))
            {
                return "NA";
            }
            else
            {
                return stringValue;
            }

        }

        //This method is used as connection string logic for SQL database
        public static string connectionString()
        {
            //return "Data Source= .;Initial Catalog=ApartmentDatabase_Final;Integrated Security=False;User Id=Animesh;Password=#Animesh2016;MultipleActiveResultSets=True";
            return ConfigurationManager.ConnectionStrings["ApartmentDBContext"].ConnectionString;
        }

        //This method is used to calculate the discount
        public static double DiscountPercent(DateTime bookingDate, DateTime moveInDate)
        {
            if ((moveInDate - bookingDate).TotalDays > 0)
            {
                if ((moveInDate - bookingDate).TotalDays >= 30 && (moveInDate - bookingDate).TotalDays < 60)
                {
                    return 5;
                }
                else if ((moveInDate - bookingDate).TotalDays >= 60)
                {
                    return 10;
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return 0;
            }
        }

        public static double FinalRent( double Rent, double DiscountPercent)
        {
            return Rent - ((Rent * DiscountPercent) / 100);
        }

        //This method is used to encrypt the string password into SHA1 format
        public static string EncryptPassword(string password)
        {
            MD5 md5Hasher = MD5.Create();
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(password));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
            //return FormsAuthentication.HashPasswordForStoringInConfigFile(password, "SHA1");
        }

        private bool IsFileValid(string FileContentType)
        {
            return FileContentType.Equals("image/jpg") || FileContentType.Equals("image/jpeg")
                || FileContentType.Equals("image/png") || FileContentType.Equals("image/gif");
        }

        private bool IfFileLengthValid(int FileLength)
        {
            return (FileLength / 1024) / 1024 < 1;
        }        
    }
}
