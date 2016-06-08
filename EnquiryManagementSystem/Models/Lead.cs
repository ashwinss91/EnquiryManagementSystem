namespace EnquiryManagementSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Lead
    {
        public int Id { get; set; }

        [Required]
        public string CustomerName { get; set; }

        [Required]
        public string FirmName { get; set; }

        [Required]
        public string ContactNo { get; set; }

        [Required]
        public string EmailId { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        public string EnquiryDate { get; set; }

        [Required]
        public string Comments { get; set; }

        [Required]
        public string CreatedOn { get; set; }

        [Required]
        public string CreatedBy { get; set; }

        [Required]
        public string ModifiedOn { get; set; }

        [Required]
        public string ModifiedBy { get; set; }

        public int EnquiryTypeId { get; set; }

        public int CustomerProfileId { get; set; }

        public int SalesTeamId { get; set; }

        public int EventId { get; set; }

        public int ApplicationId { get; set; }

        public int UserId { get; set; }

        public int AdvertisementId { get; set; }

        public int IsUrgent { get; set; }

        public int IsQualify { get; set; }

        public int IsDisQualify { get; set; }

        public int IsDeactivate { get; set; }

        public int Opportunity_Id { get; set; }

        public virtual Advertisement Advertisement { get; set; }

        public virtual Application Application { get; set; }

        public virtual CustomerProfile CustomerProfile { get; set; }

        public virtual EnquiryType EnquiryType { get; set; }

        public virtual Event Event { get; set; }

        public virtual Opportunity Opportunity { get; set; }

        public virtual SalesTeam SalesTeam { get; set; }

        public virtual User User { get; set; }
    }
}
