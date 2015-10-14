using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Hermes.Data.Models.Mapping
{
    public class MemberMap : EntityTypeConfiguration<Member>
    {
        public MemberMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("Members");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.FamilyRolesId).HasColumnName("FamilyRolesId");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.HouseholdId).HasColumnName("HouseholdId");

            // Relationships
            this.HasMany(t => t.Regulars1)
                .WithMany(t => t.Members)
                .Map(m =>
                    {
                        m.ToTable("RegularTrips");
                        m.MapLeftKey("MemberId");
                        m.MapRightKey("RegularId");
                    });

            this.HasOptional(t => t.FamilyRole)
                .WithMany(t => t.Members)
                .HasForeignKey(d => d.FamilyRolesId);
            this.HasRequired(t => t.Household)
                .WithMany(t => t.Members)
                .HasForeignKey(d => d.HouseholdId);

        }
    }
}
