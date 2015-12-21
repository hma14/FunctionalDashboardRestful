using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace FunctionalDashboardRestful.Models.Mapping
{
    public class NCSInfoMap : EntityTypeConfiguration<NCSInfo>
    {
        public NCSInfoMap()
        {
            // Primary Key
            this.HasKey(t => new { t.InstitutionId, t.ProgramId, t.Active, t.Name });

            // Properties
            this.Property(t => t.InstitutionId)
                .IsRequired()
                .HasMaxLength(10);

            this.Property(t => t.ProgramId)
                .IsRequired()
                .HasMaxLength(10);

            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.ShortName)
                .HasMaxLength(24);

            // Table & Column Mappings
            this.ToTable("NCSInfo");
            this.Property(t => t.OrganizationId).HasColumnName("OrganizationId");
            this.Property(t => t.InstitutionId).HasColumnName("InstitutionId");
            this.Property(t => t.ProgramId).HasColumnName("ProgramId");
            this.Property(t => t.Active).HasColumnName("Active");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.ShortName).HasColumnName("ShortName");
        }
    }
}
