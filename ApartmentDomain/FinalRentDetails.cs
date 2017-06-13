using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmentDomain
{
    public class FinalRentDetails : BookingDetails
    {
        public double DiscountPercent { get; set; }
        public double FinalRent { get; set; }
    }
}
