using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Hermes.Data.Models.Mapping
{
    public class AdditionalTripMap : EntityTypeConfiguration<AdditionalTrip>
    {
        public AdditionalTripMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Notes)
                .HasMaxLength(225);

            // Table & Column Mappings
            this.ToTable("AdditionalTrip");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.RegularId).HasColumnName("RegularId");
            this.Property(t => t.AdditionalId).HasColumnName("AdditionalId");
            this.Property(t => t.Number).HasColumnName("Number");
            this.Property(t => t.Notes).HasColumnName("Notes");

            // Relationships
            this.HasRequired(t => t.Additional)
                .WithMany(t => t.AdditionalTrips)
                .HasForeignKey(d => d.AdditionalId);
            this.HasRequired(t => t.Regular)
                .WithMany(t => t.AdditionalTrips)
                .HasForeignKey(d => d.RegularId);

        }
    }
}
