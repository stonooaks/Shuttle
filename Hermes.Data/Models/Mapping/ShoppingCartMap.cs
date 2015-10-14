using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Hermes.Data.Models.Mapping
{
    public class ShoppingCartMap : EntityTypeConfiguration<ShoppingCart>
    {
        public ShoppingCartMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("ShoppingCart");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.RegularId).HasColumnName("RegularId");
            this.Property(t => t.TotalCost).HasColumnName("TotalCost");
            this.Property(t => t.ShoppingCartDate).HasColumnName("ShoppingCartDate");
            this.Property(t => t.HouseholdID).HasColumnName("HouseholdID");

            // Relationships
            this.HasRequired(t => t.Regular)
                .WithMany(t => t.ShoppingCarts)
                .HasForeignKey(d => d.RegularId);

        }
    }
}
