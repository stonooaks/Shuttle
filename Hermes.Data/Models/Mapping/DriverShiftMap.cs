using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Hermes.Data.Models.Mapping
{
    public class DriverShiftMap : EntityTypeConfiguration<DriverShift>
    {
        public DriverShiftMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.DriverShift1)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("DriverShift");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.DriverShift1).HasColumnName("DriverShift");
        }
    }
}
