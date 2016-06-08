namespace EnquiryManagementSystem.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class EnquiryContext : DbContext
    {
        public EnquiryContext()
            : base("name=EnquiryContext")
        {
        }

        public virtual DbSet<Advertisement> Advertisements { get; set; }
        public virtual DbSet<Application> Applications { get; set; }
        public virtual DbSet<CustomerProfile> CustomerProfiles { get; set; }
        public virtual DbSet<EnquiryRisk> EnquiryRisks { get; set; }
        public virtual DbSet<EnquiryStage> EnquiryStages { get; set; }
        public virtual DbSet<EnquiryStatu> EnquiryStatus { get; set; }
        public virtual DbSet<EnquiryType> EnquiryTypes { get; set; }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<Lead> Leads { get; set; }
        public virtual DbSet<Opportunity> Opportunities { get; set; }
        public virtual DbSet<Priority> Priorities { get; set; }
        public virtual DbSet<RoleType> RoleTypes { get; set; }
        public virtual DbSet<SalesTeam> SalesTeams { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Advertisement>()
                .HasMany(e => e.Leads)
                .WithRequired(e => e.Advertisement)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Application>()
                .HasMany(e => e.Leads)
                .WithRequired(e => e.Application)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CustomerProfile>()
                .HasMany(e => e.Leads)
                .WithRequired(e => e.CustomerProfile)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EnquiryRisk>()
                .HasMany(e => e.Opportunities)
                .WithRequired(e => e.EnquiryRisk)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EnquiryStage>()
                .HasMany(e => e.Opportunities)
                .WithRequired(e => e.EnquiryStage)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EnquiryStatu>()
                .HasMany(e => e.Opportunities)
                .WithRequired(e => e.EnquiryStatu)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EnquiryType>()
                .HasMany(e => e.Leads)
                .WithRequired(e => e.EnquiryType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Event>()
                .HasMany(e => e.Leads)
                .WithRequired(e => e.Event)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Opportunity>()
                .HasMany(e => e.Leads)
                .WithRequired(e => e.Opportunity)
                .HasForeignKey(e => e.Opportunity_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Priority>()
                .HasMany(e => e.Opportunities)
                .WithRequired(e => e.Priority)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RoleType>()
                .HasMany(e => e.Users)
                .WithRequired(e => e.RoleType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SalesTeam>()
                .HasMany(e => e.Leads)
                .WithRequired(e => e.SalesTeam)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Leads)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);
        }
    }
}
