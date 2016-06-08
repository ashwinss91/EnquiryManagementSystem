namespace EnquiryManagementSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Event
    {
        public Event()
        {
            Leads = new HashSet<Lead>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string EventDate { get; set; }

        [Required]
        public string EventLocation { get; set; }

        public virtual ICollection<Lead> Leads { get; set; }
    }
}
