//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Echo.Data.Repository
{
    using System;
    using System.Collections.Generic;
    
    public partial class LogSheet
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LogSheet()
        {
            this.LogSheetActivities = new HashSet<LogSheetActivity>();
        }
    
        public System.Guid ID { get; set; }
        public string Item { get; set; }
        public Nullable<int> Quantity { get; set; }
        public Nullable<System.DateTime> DateModified { get; set; }
        public Nullable<System.Guid> ModifiedBy { get; set; }
    
        public virtual UserProfile UserProfile { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LogSheetActivity> LogSheetActivities { get; set; }
    }
}
