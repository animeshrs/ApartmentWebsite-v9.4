using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using ApartmentDomain;
using System.Web;
using System.IO;

namespace ApartmentBusinessLayer
{
    public class PersonBusinessLayer : IPersonInterface
    {
        public IEnumerable<Person> People()
        {            
            List<Person> people = new List<Person>();
            string connectionString = UtilityClass.connectionString();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spGetPeopleList", con);
                cmd.CommandType = CommandType.StoredProcedure;
                
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {                    
                    Person person = new Person();
                    person.Person_ID = Convert.ToInt32(sdr["Person_ID"]);
                    person.UserName = sdr["UserName"].ToString();                 
                    person.FirstName = sdr["FirstName"].ToString();
                    person.LastName = sdr["LastName"].ToString();
                    person.Age = Convert.ToInt32(sdr["Age"]);
                    person.Email = sdr["Email"].ToString();
                    person.Password = sdr["Password"].ToString();
                    person.Mobile = sdr["Mobile"].ToString();
                    person.Telephone = sdr["Telephone"].ToString();
                    person.IsMarried = Convert.ToBoolean(sdr["IsMarried"]);
                    person.PersonType = sdr["PersonType"].ToString();

                    HttpContext.Current.Session["PersonID"] = person.Person_ID;

                    people.Add(person);
                    
                }
            }
            return people;
        }
        
        public Person RegisterPerson(Person person)
        {
            string connectionString = UtilityClass.connectionString();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spAddPerson", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter UserName = new SqlParameter("@UserName", HttpUtility.HtmlEncode(person.UserName));
                cmd.Parameters.Add(UserName);

                SqlParameter FirstName = new SqlParameter("@FirstName", HttpUtility.HtmlEncode(person.FirstName));
                cmd.Parameters.Add(FirstName);

                SqlParameter LastName = new SqlParameter("@LastName", HttpUtility.HtmlEncode(person.LastName));
                cmd.Parameters.Add(LastName);

                SqlParameter Age = new SqlParameter("@Age", HttpUtility.HtmlEncode(person.Age));
                cmd.Parameters.Add(Age);
                
                SqlParameter Email = new SqlParameter("@Email", HttpUtility.HtmlEncode(person.Email));
                cmd.Parameters.Add(Email);

                string encryptedPassword = UtilityClass.EncryptPassword(person.Password);
                SqlParameter Password = new SqlParameter("@Password", HttpUtility.HtmlEncode(encryptedPassword));
                cmd.Parameters.Add(Password);

                SqlParameter Mobile = new SqlParameter("@Mobile", HttpUtility.HtmlEncode(person.Mobile));
                cmd.Parameters.Add(Mobile);

                SqlParameter Telephone = new SqlParameter();
                Telephone.ParameterName = "@Telephone";
                Telephone.Value = HttpUtility.HtmlEncode(UtilityClass.IsNullable(person.Telephone));
                cmd.Parameters.Add(Telephone);

                SqlParameter IsMarried = new SqlParameter("@IsMarried", HttpUtility.HtmlEncode(person.IsMarried));
                cmd.Parameters.Add(IsMarried);

                SqlParameter PersonType = new SqlParameter("@PersonType", HttpUtility.HtmlEncode(person.PersonType));
                cmd.Parameters.Add(PersonType);

                con.Open();
                //cmd.ExecuteNonQuery();
                object Id = cmd.ExecuteScalar();
                if (Id != null)
                    person.Person_ID = Convert.ToInt32(Id);

                return person;
            }
        }
        public void InsertPersonRole(string role, int personId)
        {
            string connectionString = UtilityClass.connectionString();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string roleID = string.Empty;
                string rol = "Select RoleId from Role where RoleName=@RoleName";
                string query = "Insert into UserRole(RoleId,Person_Id) values(@RoleId,@Person_Id)";
                con.Open();
                SqlCommand cmd = new SqlCommand(rol, con);
                SqlCommand cmd1 = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@RoleName", role);
                object rid = cmd.ExecuteScalar();
                if (rid != null)
                    roleID = rid.ToString();
                cmd1.Parameters.AddWithValue("@RoleId", roleID);
                cmd1.Parameters.AddWithValue("@Person_Id", personId.ToString());
                cmd1.ExecuteNonQuery();
                con.Close();

            }
        }
        public void UpdatePerson(Person person)
        {
            string connectionString = UtilityClass.connectionString();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spUpdatePerson", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter Person_ID = new SqlParameter("@Person_ID", HttpUtility.HtmlEncode(person.Person_ID));
                cmd.Parameters.Add(Person_ID);

                SqlParameter FirstName = new SqlParameter("@FirstName", HttpUtility.HtmlEncode(person.FirstName));
                cmd.Parameters.Add(FirstName);

                SqlParameter LastName = new SqlParameter("@LastName", HttpUtility.HtmlEncode(person.LastName));
                cmd.Parameters.Add(LastName);

                SqlParameter Age = new SqlParameter("@Age", HttpUtility.HtmlEncode(person.Age));
                cmd.Parameters.Add(Age);

                SqlParameter Email = new SqlParameter("@Email", HttpUtility.HtmlEncode(person.Email));
                cmd.Parameters.Add(Email);

                SqlParameter Mobile = new SqlParameter("@Mobile", HttpUtility.HtmlEncode(person.Mobile));
                cmd.Parameters.Add(Mobile);

                SqlParameter Telephone = new SqlParameter();
                Telephone.ParameterName = "@Telephone";
                Telephone.Value = UtilityClass.IsNullable(HttpUtility.HtmlEncode(person.Telephone));
                cmd.Parameters.Add(Telephone);

                SqlParameter IsMarried = new SqlParameter("@IsMarried", HttpUtility.HtmlEncode(person.IsMarried));
                cmd.Parameters.Add(IsMarried);

                SqlParameter PersonType = new SqlParameter("@PersonType", HttpUtility.HtmlEncode(person.PersonType));
                cmd.Parameters.Add(PersonType);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeletePerson(int PersonID)
        {
            string connectionString = UtilityClass.connectionString();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spDeletePerson", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter Person_ID = new SqlParameter("@Person_ID", PersonID);
                //Person_ID.ParameterName = "@Person_ID";
                //Person_ID.Value = PersonID;
                cmd.Parameters.Add(Person_ID);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public bool AuthenticateUserDetails(string UserName, string Password)
        {
            string connectionString = UtilityClass.connectionString();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spValidateUser", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter userName = new SqlParameter("@UserName", UserName);
                cmd.Parameters.Add(userName);

                string encryptedPassword = UtilityClass.EncryptPassword(Password);
                SqlParameter passWord = new SqlParameter("@Password", encryptedPassword);
                cmd.Parameters.Add(passWord);

                con.Open();
                int ReturnCode = (int)cmd.ExecuteScalar();
                return ReturnCode == 1;
            }
        }

        public void UploadDocuments(HttpPostedFileBase postedFile) 
        {
            if (postedFile != null && postedFile.ContentLength > 0)
            {
                var postedFileName = Path.GetFileName(postedFile.FileName);

                var filePath = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~/Content/Documents/"), postedFileName);
                postedFile.SaveAs(filePath);
            }
        }
    }
}