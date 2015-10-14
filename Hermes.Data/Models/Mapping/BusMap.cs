using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Hermes.Data.Models.Mapping
{
    public class BusMap : EntityTypeConfiguration<Bus>
    {
        public BusMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("Buses");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.StopsId).HasColumnName("StopsId");
            this.Property(t => t.TripTypeId).HasColumnName("TripTypeId");
            this.Property(t => t.Kiawah_Id).HasColumnName("Kiawah_Id");
            this.Property(t => t.DriverId).HasColumnName("DriverId");
            this.Property(t => t.BusTimeId).HasColumnName("BusTimeId");
            this.Property(t => t.Date).HasColumnName("Date");
            this.Property(t => t.GuestId).HasColumnName("GuestId");

            // Relationships
            this.HasMany(t => t.Members)
                .WithMany(t => t.Buses)
                .Map(m =>
                    {
                        m.ToTable("BusTrips");
                        m.MapLeftKey("BusId");
                        m.MapRightKey("MemberId");
                    });

            this.HasOptional(t => t.BusTime)
                .WithMany(t => t.Buses)
                .HasForeignKey(d => d.BusTimeId);
            this.HasOptional(t => t.Guest)
                .WithMany(t => t.Buses)
                .HasForeignKey(d => d.GuestId);
            this.HasRequired(t => t.Intersection)
                .WithMany(t => t.Buses)
                .HasForeignKey(d => d.StopsId);
            this.HasRequired(t => t.RouteStop)
                .WithMany(t => t.Buses)
                .HasForeignKey(d => d.StopsId);
            this.HasRequired(t => t.Driver)
                .WithMany(t => t.Buses)
                .HasForeignKey(d => d.DriverId);
            this.HasOptional(t => t.Kiawah)
                .WithMany(t => t.Buses)
                .HasForeignKey(d => d.Kiawah_Id);
            this.HasRequired(t => t.TripType)
                .WithMany(t => t.Buses)
                .HasForeignKey(d => d.TripTypeId);

        }
    }
}
