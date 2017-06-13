using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ApartmentDomain
{
    public class Address
    {
        [Key]
        public int address_ID { get; set; }

        [Required(ErrorMessage = "Flat Number is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Flat-Number can't be negative!  ")]
        public int FlatNumber { get; set; }
        
        public string HouseName { get; set; }

        [Required(ErrorMessage = "Number of rooms is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Number of rooms can't be negative!  ")]
        public int NumberOfRooms { get; set; }

        [Required(ErrorMessage = "Room description is required")]
        public string DescriptionOfRoom { get; set; }

        [Required(ErrorMessage = "Room Rent is required")]
        [Range(1, double.MaxValue, ErrorMessage = "Kindly assign Initial Rent")]
        public double InitialRent { get; set; }

        [Required(ErrorMessage = "Room Deposit is required")]
        [Range(1, double.MaxValue, ErrorMessage = "Kindly assign Initial Deposit")]
        public double InitialDeposit { get; set; }

        [Required(ErrorMessage = "Is Room available for renting?")]
        public bool IsRoomAvailable { get; set; }

        public int OwnerID { get; set; }

        public string Photos { get; set; }
        
        public string Street { get; set; }
        
        [Required(ErrorMessage = "City is required")]
        public string City { get; set; }

        [Required(ErrorMessage = "Country is required")]
        public string Country { get; set; }

        public string ZipCode { get; set; }
    }
}
