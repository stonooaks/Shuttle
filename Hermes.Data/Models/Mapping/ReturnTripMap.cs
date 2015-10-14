using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Hermes.Data.Models.Mapping
{
    public class ReturnTripMap : EntityTypeConfiguration<ReturnTrip>
    {
        public ReturnTripMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.TripLocation)
                .HasMaxLength(50);

            this.Property(t => t.KiawahLocation)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("ReturnTrip");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.RegularId).HasColumnName("RegularId");
            this.Property(t => t.PickupTime).HasColumnName("PickupTime");
            this.Property(t => t.TripLocation).HasColumnName("TripLocation");
            this.Property(t => t.KiawahLocation).HasColumnName("KiawahLocation");

            // Relationships
            this.HasRequired(t => t.Regular)
                .WithMany(t => t.ReturnTrips)
                .HasForeignKey(d => d.RegularId);

        }
    }
}
