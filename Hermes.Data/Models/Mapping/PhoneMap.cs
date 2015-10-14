using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Hermes.Data.Models.Mapping
{
    public class PhoneMap : EntityTypeConfiguration<Phone>
    {
        public PhoneMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("Phones");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Number).HasColumnName("Number");
            this.Property(t => t.MemberId).HasColumnName("MemberId");

            // Relationships
            this.HasOptional(t => t.Member)
                .WithMany(t => t.Phones)
                .HasForeignKey(d => d.MemberId);

        }
    }
}
