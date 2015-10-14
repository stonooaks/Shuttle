using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Hermes.Data.Models.Mapping
{
    public class AdditionalMap : EntityTypeConfiguration<Additional>
    {
        public AdditionalMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Additional");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.AdditionalTypeId).HasColumnName("AdditionalTypeId");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Cost).HasColumnName("Cost");

            // Relationships
            this.HasRequired(t => t.AdditionalType)
                .WithMany(t => t.Additionals)
                .HasForeignKey(d => d.AdditionalTypeId);

        }
    }
}
