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
    
    public partial class tblAmenity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblAmenity()
        {
            this.tblAddresses = new HashSet<tblAddress>();
        }
    
        public int amenity_ApartmentNumber { get; set; }
        public int amenity_ApartmentID { get; set; }
        public bool amenity_Water { get; set; }
        public bool amenity_Electricity { get; set; }
        public bool amenity_Housekeeping { get; set; }
        public Nullable<bool> amenity_RoomHeater { get; set; }
        public Nullable<bool> amenity_Bin { get; set; }
        public Nullable<bool> amenity_Maintenance { get; set; }
        public Nullable<bool> amenity_Parking { get; set; }
        public Nullable<bool> amenity_WashingMachine { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblAddress> tblAddresses { get; set; }
        public virtual tblApartment tblApartment { get; set; }
    }
}
