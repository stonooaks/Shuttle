using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Hermes.Data.Models.Mapping
{
    public class RouteStopMap : EntityTypeConfiguration<RouteStop>
    {
        public RouteStopMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("RouteStops");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.POIId).HasColumnName("POIId");

            // Relationships
            this.HasRequired(t => t.POIs)
                .WithMany(t => t.RouteStops)
                .HasForeignKey(d => d.POIId);

        }
    }
}
