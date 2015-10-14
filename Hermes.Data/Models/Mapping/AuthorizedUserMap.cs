using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Hermes.Data.Models.Mapping
{
    public class AuthorizedUserMap : EntityTypeConfiguration<AuthorizedUser>
    {
        public AuthorizedUserMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("AuthorizedUsers");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.HouseholdId).HasColumnName("HouseholdId");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.DateCreated).HasColumnName("DateCreated");
            this.Property(t => t.DateExpired).HasColumnName("DateExpired");

            // Relationships
            this.HasRequired(t => t.Household)
                .WithMany(t => t.AuthorizedUsers)
                .HasForeignKey(d => d.HouseholdId);

        }
    }
}
