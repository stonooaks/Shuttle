using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Hermes.Data.Models.Mapping
{
    public class DailyHourMap : EntityTypeConfiguration<DailyHour>
    {
        public DailyHourMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            // Table & Column Mappings
            this.ToTable("DailyHours");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.Day).HasColumnName("Day");
            this.Property(t => t.Miles).HasColumnName("Miles");
            this.Property(t => t.VehicleId).HasColumnName("VehicleId");

            // Relationships
            this.HasOptional(t => t.Vehicle)
                .WithMany(t => t.DailyHours)
                .HasForeignKey(d => d.VehicleId);

        }
    }
}
