//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Qaarya.Data.DataModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class QaaryaMedia
    {
        public long MediaID { get; set; }
        public Nullable<long> MediaProfileID { get; set; }
        public string MediaUserID { get; set; }
        public string MediaName { get; set; }
        public string MediaURL { get; set; }
        public string MediaAlternateName { get; set; }
        public Nullable<System.DateTime> MediaDateCreated { get; set; }
        public Nullable<System.DateTime> MediaDateModified { get; set; }
        public Nullable<System.DateTime> MediaDateDeleted { get; set; }
    
        public virtual AspNetUser AspNetUser { get; set; }
        public virtual QaaryaProfile QaaryaProfile { get; set; }
    }
}
