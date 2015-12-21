using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace FunctionalDashboardRestful.Models.Mapping
{
    public class CPGFD_UsersMap : EntityTypeConfiguration<CPGFD_Users>
    {
        public CPGFD_UsersMap()
        {
            // Primary Key
            this.HasKey(t => t.UserID);

            // Properties
            this.Property(t => t.UserName)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.FullName)
                .HasMaxLength(255);

            this.Property(t => t.Email)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("CPGFD_Users");
            this.Property(t => t.UserID).HasColumnName("UserID");
            this.Property(t => t.UserName).HasColumnName("UserName");
            this.Property(t => t.FullName).HasColumnName("FullName");
            this.Property(t => t.Email).HasColumnName("Email");
        }
    }
}
