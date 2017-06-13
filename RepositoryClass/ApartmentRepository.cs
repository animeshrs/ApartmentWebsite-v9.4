using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApartmentBusinessLayer;
using ApartmentDomain;

namespace ApartmentRepositoryClass
{
    public static class AddressRepository
    {
        public static IApartmentInterface IapartmentBusinessLayer()
        {
            IApartmentInterface apartmentBusinessLayer = null;
            apartmentBusinessLayer = new ApartmentBusinessLayer.ApartmentBusinessLayer();
            
            return apartmentBusinessLayer;
        }
    }
}