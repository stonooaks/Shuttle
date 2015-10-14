using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Hermes.Data.Models.Mapping
{
    public class RegularMap : EntityTypeConfiguration<Regular>
    {
        public RegularMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.KiawahLocation)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.TripLocation)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.OfficerName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Email)
                .HasMaxLength(50);

            this.Property(t => t.Phone)
                .HasMaxLength(50);

            this.Property(t => t.otherAddress)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Regulars");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.HHID).HasColumnName("HHID");
            this.Property(t => t.MemberId).HasColumnName("MemberId");
            this.Property(t => t.TripTypeId).HasColumnName("TripTypeId");
            this.Property(t => t.KiawahLocation).HasColumnName("KiawahLocation");
            this.Property(t => t.TripLocation).HasColumnName("TripLocation");
            this.Property(t => t.NonKiawahPickup).HasColumnName("NonKiawahPickup");
            this.Property(t => t.DriverId).HasColumnName("DriverId");
            this.Property(t => t.Date).HasColumnName("Date");
            this.Property(t => t.PickupTime).HasColumnName("PickupTime");
            this.Property(t => t.OfficerName).HasColumnName("OfficerName");
            this.Property(t => t.VehicleId).HasColumnName("VehicleId");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.Phone).HasColumnName("Phone");
            this.Property(t => t.Notes).HasColumnName("Notes");
            this.Property(t => t.Count).HasColumnName("Count");
            this.Property(t => t.IsCancelled).HasColumnName("IsCancelled");
            this.Property(t => t.otherAddress).HasColumnName("otherAddress");
            this.Property(t => t.Cost).HasColumnName("Cost");

            // Relationships
            this.HasOptional(t => t.Driver)
                .WithMany(t => t.Regulars)
                .HasForeignKey(d => d.DriverId);
            this.HasRequired(t => t.Household)
                .WithMany(t => t.Regulars)
                .HasForeignKey(d => d.HHID);
            this.HasOptional(t => t.Member)
                .WithMany(t => t.Regulars)
                .HasForeignKey(d => d.MemberId);
            this.HasRequired(t => t.TripType)
                .WithMany(t => t.Regulars)
                .HasForeignKey(d => d.TripTypeId);
            this.HasOptional(t => t.Vehicle)
                .WithMany(t => t.Regulars)
                .HasForeignKey(d => d.VehicleId);

        }
    }
}
