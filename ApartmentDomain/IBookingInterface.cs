using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmentDomain
{
    public interface IBookingInterface
    {
        double BookingDetails(int AddressID);

        void RegisterBooking(BookingDetails bookingDetails);

        IEnumerable<RentDetails> GetApartmentRent();
        
        IEnumerable<FinalRentDetails> FinalRentDetails();
    }
}
