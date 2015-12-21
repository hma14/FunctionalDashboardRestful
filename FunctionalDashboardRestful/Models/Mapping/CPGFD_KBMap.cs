using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace FunctionalDashboardRestful.Models.Mapping
{
    public class CPGFD_KBMap : EntityTypeConfiguration<CPGFD_KB>
    {
        public CPGFD_KBMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.CreatedBy)
                .HasMaxLength(50);

            this.Property(t => t.UpdatedBy)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("CPGFD_KB");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.EventID).HasColumnName("EventID");
            this.Property(t => t.CategoryID).HasColumnName("CategoryID");
            this.Property(t => t.Status).HasColumnName("Status");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.PotentialErrors).HasColumnName("PotentialErrors");
            this.Property(t => t.BusinessImpact).HasColumnName("BusinessImpact");
            this.Property(t => t.Sev).HasColumnName("Sev");
            this.Property(t => t.Resolutions).HasColumnName("Resolutions");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.CreatedDatetime).HasColumnName("CreatedDatetime");
            this.Property(t => t.UpdatedBy).HasColumnName("UpdatedBy");
            this.Property(t => t.UpdatedDatetime).HasColumnName("UpdatedDatetime");
        }
    }
}
