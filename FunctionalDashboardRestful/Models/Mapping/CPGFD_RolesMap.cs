using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace FunctionalDashboardRestful.Models.Mapping
{
    public class CPGFD_RolesMap : EntityTypeConfiguration<CPGFD_Roles>
    {
        public CPGFD_RolesMap()
        {
            // Primary Key
            this.HasKey(t => t.RoleID);

            // Properties
            this.Property(t => t.RoleName)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("CPGFD_Roles");
            this.Property(t => t.RoleID).HasColumnName("RoleID");
            this.Property(t => t.RoleName).HasColumnName("RoleName");
        }
    }
}
