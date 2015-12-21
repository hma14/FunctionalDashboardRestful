using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace FunctionalDashboardRestful.Models.Mapping
{
    public class CPGFD_SLTRulesMap : EntityTypeConfiguration<CPGFD_SLTRules>
    {
        public CPGFD_SLTRulesMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.ProgramID)
                .IsRequired()
                .HasMaxLength(10);

            this.Property(t => t.InstitutionID)
                .IsRequired()
                .HasMaxLength(10);

            this.Property(t => t.UpdatedUser)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("CPGFD_SLTRules");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.ProgramID).HasColumnName("ProgramID");
            this.Property(t => t.InstitutionID).HasColumnName("InstitutionID");
            this.Property(t => t.CategoryID).HasColumnName("CategoryID");
            this.Property(t => t.EventID).HasColumnName("EventID");
            this.Property(t => t.RuleType).HasColumnName("RuleType");
            this.Property(t => t.DayOfWeek).HasColumnName("DayOfWeek");
            this.Property(t => t.RuleDay).HasColumnName("RuleDay");
            this.Property(t => t.RuleTime).HasColumnName("RuleTime");
            this.Property(t => t.WarningThreshold).HasColumnName("WarningThreshold");
            this.Property(t => t.Status).HasColumnName("Status");
            this.Property(t => t.NextTriggerDatetime).HasColumnName("NextTriggerDatetime");
            this.Property(t => t.UpdatedDatetime).HasColumnName("UpdatedDatetime");
            this.Property(t => t.UpdatedUser).HasColumnName("UpdatedUser");
            this.Property(t => t.RuleDescription).HasColumnName("RuleDescription");
        }
    }
}
