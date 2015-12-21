using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace FunctionalDashboardRestful.Models.Mapping
{
    public class SLTTrackingHistoryMap : EntityTypeConfiguration<SLTTrackingHistory>
    {
        public SLTTrackingHistoryMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.UpdatedBy)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("SLTTrackingHistory");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.SLTTrackingID).HasColumnName("SLTTrackingID");
            this.Property(t => t.Message).HasColumnName("Message");
            this.Property(t => t.UpdatedBy).HasColumnName("UpdatedBy");
            this.Property(t => t.UpdatedDatetime).HasColumnName("UpdatedDatetime");
        }
    }
}
