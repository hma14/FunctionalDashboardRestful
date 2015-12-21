using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace FunctionalDashboardRestful.Models.Mapping
{
    public class CPGFD_SLTTrackingMap : EntityTypeConfiguration<CPGFD_SLTTracking>
    {
        public CPGFD_SLTTrackingMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.ProgramID)
                .IsRequired()
                .HasMaxLength(10);

            this.Property(t => t.InstitutionID)
                .IsRequired()
                .HasMaxLength(10);

            this.Property(t => t.UpdatedUser)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("CPGFD_SLTTracking");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.EventID).HasColumnName("EventID");
            this.Property(t => t.CategoryID).HasColumnName("CategoryID");
            this.Property(t => t.ProgramID).HasColumnName("ProgramID");
            this.Property(t => t.InstitutionID).HasColumnName("InstitutionID");
            this.Property(t => t.SLTRuleID).HasColumnName("SLTRuleID");
            this.Property(t => t.RuleDescription).HasColumnName("RuleDescription");
            this.Property(t => t.SLTStartDatetime).HasColumnName("SLTStartDatetime");
            this.Property(t => t.SLTWarningDatetime).HasColumnName("SLTWarningDatetime");
            this.Property(t => t.SLTBreachDatetime).HasColumnName("SLTBreachDatetime");
            this.Property(t => t.SLTCompleteDatetime).HasColumnName("SLTCompleteDatetime");
            this.Property(t => t.Status).HasColumnName("Status");
            this.Property(t => t.UpdatedDatetime).HasColumnName("UpdatedDatetime");
            this.Property(t => t.UpdatedUser).HasColumnName("UpdatedUser");

            // Relationships
            this.HasOptional(t => t.CPGFD_SLTRules)
                .WithMany(t => t.CPGFD_SLTTracking)
                .HasForeignKey(d => d.SLTRuleID);

        }
    }
}
