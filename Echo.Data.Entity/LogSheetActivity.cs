//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Echo.Data.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class LogSheetActivity
    {
        public System.Guid ID { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<System.Guid> ItemID { get; set; }
        public Nullable<int> Balance { get; set; }
        public Nullable<int> Quantity { get; set; }
        public string Purpose { get; set; }
        public string Area { get; set; }
        public Nullable<System.Guid> IssuedBy { get; set; }
        public string ReceivedBy { get; set; }
    
        public virtual LogSheet LogSheet { get; set; }
        public virtual UserProfile UserProfile { get; set; }
    }
}
