namespace EnquiryManagementSystem.Models.Enquiries
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class EnquiryRisk
    {
        public EnquiryRisk()
        {
            Opportunities = new HashSet<Opportunity>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Opportunity> Opportunities { get; set; }
    }
}
