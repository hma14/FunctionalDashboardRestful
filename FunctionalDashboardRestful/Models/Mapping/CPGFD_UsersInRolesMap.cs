using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace FunctionalDashboardRestful.Models.Mapping
{
    public class CPGFD_UsersInRolesMap : EntityTypeConfiguration<CPGFD_UsersInRoles>
    {
        public CPGFD_UsersInRolesMap()
        {
            // Primary Key
            this.HasKey(t => new { t.RoleID, t.UserID });

            // Properties
            this.Property(t => t.RoleID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.UserID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("CPGFD_UsersInRoles");
            this.Property(t => t.RoleID).HasColumnName("RoleID");
            this.Property(t => t.UserID).HasColumnName("UserID");
        }
    }
}
