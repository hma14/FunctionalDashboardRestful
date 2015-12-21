using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace FunctionalDashboardRestful.Models.Mapping
{
    public class CPGFD_ErrorListMap : EntityTypeConfiguration<CPGFD_ErrorList>
    {
        public CPGFD_ErrorListMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.ProgramID)
                .HasMaxLength(10);

            this.Property(t => t.InstitutionID)
                .HasMaxLength(10);

            this.Property(t => t.UpdatedBy)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("CPGFD_ErrorList");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.ProgramID).HasColumnName("ProgramID");
            this.Property(t => t.InstitutionID).HasColumnName("InstitutionID");
            this.Property(t => t.EventID).HasColumnName("EventID");
            this.Property(t => t.CategoryID).HasColumnName("CategoryID");
            this.Property(t => t.ProcessDatetime).HasColumnName("ProcessDatetime");
            this.Property(t => t.Status).HasColumnName("Status");
            this.Property(t => t.UpdatedBy).HasColumnName("UpdatedBy");
            this.Property(t => t.UpdatedDatetime).HasColumnName("UpdatedDatetime");
        }
    }
}
