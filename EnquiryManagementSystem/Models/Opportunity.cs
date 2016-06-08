namespace EnquiryManagementSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Opportunity
    {
        public Opportunity()
        {
            Leads = new HashSet<Lead>();
        }

        public int Id { get; set; }

        [Required]
        public string Potentials { get; set; }

        [Required]
        public string Probability { get; set; }

        [Required]
        public string ExpectedClosedDate { get; set; }

        [Required]
        public string RemainderDate { get; set; }

        [Required]
        public string Owner { get; set; }

        [Required]
        public string CreatedOn { get; set; }

        [Required]
        public string ModifiedOn { get; set; }

        [Required]
        public string CreatedBy { get; set; }

        [Required]
        public string ModifiedBy { get; set; }

        public int IsMarkComplete { get; set; }

        public int IsCRMUpdated { get; set; }

        public int IsFlag { get; set; }

        public int EnquiryStageId { get; set; }

        public int PriorityId { get; set; }

        public int EnquiryStatuId { get; set; }

        public int EnquiryRiskId { get; set; }

        public virtual EnquiryRisk EnquiryRisk { get; set; }

        public virtual EnquiryStage EnquiryStage { get; set; }

        public virtual EnquiryStatu EnquiryStatu { get; set; }

        public virtual ICollection<Lead> Leads { get; set; }

        public virtual Priority Priority { get; set; }
    }
}
