//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Hambasafe.DataAccess.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Friend
    {
        public int UserId { get; set; }
        public int FriendUserId { get; set; }
        public string Relationship { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
    
        public virtual User User { get; set; }
        public virtual User User1 { get; set; }
    }
}
