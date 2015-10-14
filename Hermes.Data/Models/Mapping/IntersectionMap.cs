using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Hermes.Data.Models.Mapping
{
    public class IntersectionMap : EntityTypeConfiguration<Intersection>
    {
        public IntersectionMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("Intersections");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.POIId).HasColumnName("POIId");

            // Relationships
            this.HasRequired(t => t.POIs)
                .WithMany(t => t.Intersections)
                .HasForeignKey(d => d.POIId);

        }
    }
}
