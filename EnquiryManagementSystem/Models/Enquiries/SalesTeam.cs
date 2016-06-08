namespace EnquiryManagementSystem.Models.Enquiries
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SalesTeam
    {
        public SalesTeam()
        {
            Leads = new HashSet<Lead>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Region { get; set; }

        [Required]
        public string Manager { get; set; }

        [Required]
        public string Category { get; set; }

        public virtual ICollection<Lead> Leads { get; set; }
    }
}
