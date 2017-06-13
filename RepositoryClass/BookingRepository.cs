using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApartmentBusinessLayer;
using ApartmentDomain;

namespace ApartmentRepositoryClass
{
    public static class BookingRepository
    {
        public static IBookingInterface IbookingBusinessLayer()
        {
            IBookingInterface bookingBusinessLayer = null;
            bookingBusinessLayer = new ApartmentBusinessLayer.ApartmentBusinessLayer();

            return bookingBusinessLayer;
        }
    }
}
