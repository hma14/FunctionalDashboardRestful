using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace FunctionalDashboardRestful.Models.Mapping
{
    public class EventIDListMap : EntityTypeConfiguration<EventIDList>
    {
        public EventIDListMap()
        {
            // Primary Key
            this.HasKey(t => t.EventID);

            // Properties
            this.Property(t => t.EventID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.EventName)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("EventIDList");
            this.Property(t => t.EventID).HasColumnName("EventID");
            this.Property(t => t.EventName).HasColumnName("EventName");
        }
    }
}
