using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Hermes.Data.Models.Mapping
{
    public class MaintenanceMap : EntityTypeConfiguration<Maintenance>
    {
        public MaintenanceMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Type)
                .HasMaxLength(50);

            this.Property(t => t.Description)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Maintenance");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Date).HasColumnName("Date");
            this.Property(t => t.Type).HasColumnName("Type");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.Cost).HasColumnName("Cost");
            this.Property(t => t.VehicleId).HasColumnName("VehicleId");

            // Relationships
            this.HasOptional(t => t.Vehicle)
                .WithMany(t => t.Maintenances)
                .HasForeignKey(d => d.VehicleId);

        }
    }
}
