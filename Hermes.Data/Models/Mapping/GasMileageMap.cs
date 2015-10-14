using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Hermes.Data.Models.Mapping
{
    public class GasMileageMap : EntityTypeConfiguration<GasMileage>
    {
        public GasMileageMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("GasMileages");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Date).HasColumnName("Date");
            this.Property(t => t.Mileage).HasColumnName("Mileage");
            this.Property(t => t.Gallons).HasColumnName("Gallons");
            this.Property(t => t.VehicleId).HasColumnName("VehicleId");

            // Relationships
            this.HasOptional(t => t.Vehicle)
                .WithMany(t => t.GasMileages)
                .HasForeignKey(d => d.VehicleId);

        }
    }
}
