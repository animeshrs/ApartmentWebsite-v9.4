//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccessLayer
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblAddress
    {
        public int address_ID { get; set; }
        public int address_FlatNumber { get; set; }
        public string address_HouseName { get; set; }
        public string address_Street { get; set; }
        public string address_City { get; set; }
    
        public virtual tblAmenity tblAmenity { get; set; }
    }
}