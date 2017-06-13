using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApartmentBusinessLayer;
using ApartmentDomain;

namespace ApartmentRepositoryClass
{
    public static class PersonRepository
    {        
        public static IPersonInterface IpersonBusinessLayer()
        {
            IPersonInterface personBusinessLayer = null;
            personBusinessLayer = new PersonBusinessLayer();

            return personBusinessLayer;      
        }
    }
}
