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
    
    public partial class tblOwnerVerification
    {
        public int owner_VerificationID { get; set; }
        public Nullable<int> owner_OwnerID { get; set; }
        public string owner_OwnerDocument { get; set; }
    
        public virtual tblOwner tblOwner { get; set; }
    }
}
