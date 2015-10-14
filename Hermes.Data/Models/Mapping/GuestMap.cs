using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Hermes.Data.Models.Mapping
{
    public class GuestMap : EntityTypeConfiguration<Guest>
    {
        public GuestMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Guests");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.RegularId).HasColumnName("RegularId");

            // Relationships
            this.HasRequired(t => t.Regular)
                .WithMany(t => t.Guests)
                .HasForeignKey(d => d.RegularId);

        }
    }
}
