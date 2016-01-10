using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace FunctionalDashboardRestful.Models.Mapping
{
    public class CategoryIDListMap : EntityTypeConfiguration<CategoryIDList>
    {
        public CategoryIDListMap()
        {
            // Primary Key
            this.HasKey(t => t.CategoryID);

            // Properties
            this.Property(t => t.CategoryName)
                .HasMaxLength(255);

            this.Property(t => t.CategoryID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("CategoryIDList");
            this.Property(t => t.CategoryName).HasColumnName("CategoryName");
            this.Property(t => t.CategoryID).HasColumnName("CategoryID");
        }
    }
}
