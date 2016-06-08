namespace EnquiryManagementSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Priority
    {
        public Priority()
        {
            Opportunities = new HashSet<Opportunity>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Opportunity> Opportunities { get; set; }
    }
}
