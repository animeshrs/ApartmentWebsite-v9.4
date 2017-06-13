using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace Apartment.Document
{
    public class HelperClass
    {
        public void InsertDocument(string personId,string DocName)
        {
            string connectionString = ConnectionString.connectionString();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string queryObj = "Insert into tblPersonVerification(Person_ID,Person_Documents) values(@Person_ID,@Person_Documents)";
                SqlCommand cmd = new SqlCommand(queryObj, con);
                con.Open();

                cmd.Parameters.AddWithValue("@Person_Documents", DocName);
                cmd.Parameters.AddWithValue("@Person_ID", personId);

                cmd.ExecuteNonQuery();
                con.Close();

            }
        }

        public List<string> GetDocNameByPersonId(string Person_ID)
        {
            List<string> docNameList = new List<string>();
            string connectionString = ConnectionString.connectionString();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string queryObj = "Select Person_Documents from tblPersonVerification where Person_ID=@Person_ID"; 
                SqlCommand cmd = new SqlCommand(queryObj, con);
                con.Open();
               
                cmd.Parameters.AddWithValue("@Person_ID", Person_ID);

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    string doc = string.Empty;
                    doc = dr["DocName"].ToString();
                    docNameList.Add(doc);
                }
                con.Close();               

            }
            return docNameList;
        }
    }
}
