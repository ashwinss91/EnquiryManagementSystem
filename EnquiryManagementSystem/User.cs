//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EnquiryManagementSystem
{
    using System;
    using System.Collections.Generic;
    
    public partial class User
    {
        public User()
        {
            this.Leads = new HashSet<Lead>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public int RoleTypeId { get; set; }
    
        public virtual ICollection<Lead> Leads { get; set; }
        public virtual RoleType RoleType { get; set; }
    }
}
