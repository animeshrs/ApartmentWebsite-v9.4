using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Apartment.Security
{
    public class HelperClass
    {
        string connectionString = ConfigurationManager.ConnectionStrings["ApartmentDBContext"].ConnectionString;
        public List<User> GetUserList()
        {
            List<User> userList = new List<User>();            
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string queryObj = "Select Username,Password from tblPerson";
                    SqlCommand cmd = new SqlCommand(queryObj, con);
                    con.Open();

                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        User user = new User();
                        user.Username = dr["Username"].ToString();
                        user.Password = dr["Password"].ToString();
                        userList.Add(user);
                    }
                    con.Close();

                }
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return userList;
        }

        public List<string> GetRolesByUser(string username)
        {
            List<string> rolList = new List<string>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string queryObj = "Select RoleName from VW_USERROLE WHERE Username=@Username";
                SqlCommand cmd = new SqlCommand(queryObj, con);
                con.Open();
                cmd.Parameters.AddWithValue("@Username", username);

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    string role = string.Empty;
                    role = dr["RoleName"].ToString();
                    rolList.Add(role);
                }
                con.Close();

            }
            return rolList;
        }
    }
}
