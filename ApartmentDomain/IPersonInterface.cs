using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmentDomain
{
    public interface IPersonInterface 
    {
        bool AuthenticateUserDetails(string UserName, string Password);

        IEnumerable<Person> People();

        Person RegisterPerson(Person person);

        void UpdatePerson(Person person);

        void DeletePerson(int PersonID);

        void InsertPersonRole(string role, int personId);
    }
}
