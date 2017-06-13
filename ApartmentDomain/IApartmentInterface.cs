using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmentDomain
{
    public interface IApartmentInterface
    {
        IEnumerable<Address> Apartments();

        void RegisterApartmentAddress(Address address);

        void UpdateApartmentAddress(Address address);

        void DeleteApartment(int apartmentID);
    }
}
