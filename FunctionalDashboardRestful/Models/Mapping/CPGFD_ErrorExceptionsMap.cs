using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace FunctionalDashboardRestful.Models.Mapping
{
    public class CPGFD_ErrorExceptionsMap : EntityTypeConfiguration<CPGFD_ErrorExceptions>
    {
        public CPGFD_ErrorExceptionsMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            // Table & Column Mappings
            this.ToTable("CPGFD_ErrorExceptions");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.EventID).HasColumnName("EventID");
            this.Property(t => t.CategoryID).HasColumnName("CategoryID");
            this.Property(t => t.Status).HasColumnName("Status");
        }
    }
}
