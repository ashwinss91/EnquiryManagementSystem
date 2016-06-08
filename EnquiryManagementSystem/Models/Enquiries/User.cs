namespace EnquiryManagementSystem.Models.Enquiries
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User
    {
        public User()
        {
            Leads = new HashSet<Lead>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int RoleTypeId { get; set; }

        public virtual ICollection<Lead> Leads { get; set; }

        public virtual RoleType RoleType { get; set; }
    }
}
