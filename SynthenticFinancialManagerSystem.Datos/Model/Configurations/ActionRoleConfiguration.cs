using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SynthenticFinancialManagerSystem.Data.Model.Entities;
using SynthenticFinancialManagerSystem.Data.Extensions;

namespace SynthenticFinancialManagerSystem.Data.Model.Configurations
{
    public class ActionRoleConfiguration : EntityTypeConfiguration<ActionRole>
    {
        public override void Configuracion(EntityTypeBuilder<ActionRole> entity)
        {
            entity.HasKey(e => new { e.Role, e.IdAction });

            entity.ToTable("ActionRole", "base");

            entity.Property(e => e.Role).HasMaxLength(50);

            entity.Property(e => e.UpdateBy).HasMaxLength(50);

            entity.Property(e => e.Active).HasDefaultValue(true);

            entity.Property(e => e.CreateBy).IsRequired().HasMaxLength(50);

            entity.HasOne(d => d.IdActionNavigation)
                .WithMany(p => p.ActionRole)
                .HasForeignKey(d => d.IdAction)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.RoleNavigation)
                .WithMany(p => p.ActionRole)
                .HasForeignKey(d => d.Role)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
