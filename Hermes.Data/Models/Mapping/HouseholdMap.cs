using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Hermes.Data.Models.Mapping
{
    public class HouseholdMap : EntityTypeConfiguration<Household>
    {
        public HouseholdMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("Households");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");

            // Relationships
            this.HasMany(t => t.KiawahAddresses)
                .WithMany(t => t.Households)
                .Map(m =>
                    {
                        m.ToTable("Ownership");
                        m.MapLeftKey("HouseholdId");
                        m.MapRightKey("KiawahLocationsId");
                    });


        }
    }
}
