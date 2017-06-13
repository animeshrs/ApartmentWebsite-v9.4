using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ApartmentDomain
{
    public class RentDetails : Address
    {
        public double Rent { get; set; }
        public double Deposit { get; set; }
    }
}
