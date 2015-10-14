using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Hermes.Data.Models.Mapping
{
    public class BillingAddressMap : EntityTypeConfiguration<BillingAddress>
    {
        public BillingAddressMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("BillingAddresses");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Address2).HasColumnName("Address2");
            this.Property(t => t.City).HasColumnName("City");
            this.Property(t => t.State).HasColumnName("State");
            this.Property(t => t.ZipCode).HasColumnName("ZipCode");
            this.Property(t => t.Country).HasColumnName("Country");
            this.Property(t => t.Address1).HasColumnName("Address1");
            this.Property(t => t.HouseholdId).HasColumnName("HouseholdId");

            // Relationships
            this.HasOptional(t => t.Household)
                .WithMany(t => t.BillingAddresses)
                .HasForeignKey(d => d.HouseholdId);

        }
    }
}
