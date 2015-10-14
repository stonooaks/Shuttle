using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Hermes.Data.Models.Mapping
{
    public class DriverMap : EntityTypeConfiguration<Driver>
    {
        public DriverMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("Drivers");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.License).HasColumnName("License");
            this.Property(t => t.ShiftId).HasColumnName("ShiftId");

            // Relationships
            this.HasOptional(t => t.DriverShift)
                .WithMany(t => t.Drivers)
                .HasForeignKey(d => d.ShiftId);

        }
    }
}
