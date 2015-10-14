using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Hermes.Data.Models.Mapping
{
    public class KiawahAddressMap : EntityTypeConfiguration<KiawahAddress>
    {
        public KiawahAddressMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("KiawahAddresses");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Address1).HasColumnName("Address1");
        }
    }
}
