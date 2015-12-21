using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace FunctionalDashboardRestful.Models.Mapping
{
    public class CPGFD_ErrorMsgMap : EntityTypeConfiguration<CPGFD_ErrorMsg>
    {
        public CPGFD_ErrorMsgMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.UpdatedBy)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("CPGFD_ErrorMsg");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.ErrorListID).HasColumnName("ErrorListID");
            this.Property(t => t.Message).HasColumnName("Message");
            this.Property(t => t.Status).HasColumnName("Status");
            this.Property(t => t.UpdatedBy).HasColumnName("UpdatedBy");
            this.Property(t => t.UpdatedDatetime).HasColumnName("UpdatedDatetime");

            // Relationships
            this.HasOptional(t => t.CPGFD_ErrorList)
                .WithMany(t => t.CPGFD_ErrorMsg)
                .HasForeignKey(d => d.ErrorListID);

        }
    }
}
