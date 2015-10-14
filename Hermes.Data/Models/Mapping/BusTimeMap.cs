using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Hermes.Data.Models.Mapping
{
    public class BusTimeMap : EntityTypeConfiguration<BusTime>
    {
        public BusTimeMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.StopLocation)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("BusTime");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.StopTime).HasColumnName("StopTime");
            this.Property(t => t.StopLocation).HasColumnName("StopLocation");
        }
    }
}
