using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Hermes.Data.Models.Mapping
{
    public class CostMap : EntityTypeConfiguration<Cost>
    {
        public CostMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("Costs");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.twoperprice).HasColumnName("twoperprice");
            this.Property(t => t.addperprice).HasColumnName("addperprice");
            this.Property(t => t.TripTypeId).HasColumnName("TripTypeId");

            // Relationships
            this.HasOptional(t => t.TripType)
                .WithMany(t => t.Costs)
                .HasForeignKey(d => d.TripTypeId);

        }
    }
}
