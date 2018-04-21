using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SynthenticFinancialManagerSystem.Data.Model.Entities;
using SynthenticFinancialManagerSystem.Data.Extensions;

namespace SynthenticFinancialManagerSystem.Data.Model.Configurations
{
    public class UserRoleConfiguracion : EntityTypeConfiguration<UserRole>
    {
        public override void Configuracion(EntityTypeBuilder<UserRole> entity)
        {
            entity.HasKey(e => new { e.IdUser, e.Role });

            entity.ToTable("UserRole", "base");

            entity.Property(e => e.Role).HasMaxLength(50);

            entity.Property(e => e.UpdateBy).HasMaxLength(50);

            entity.Property(e => e.Active).HasDefaultValue(true);

            entity.Property(e => e.CreateBy).IsRequired().HasMaxLength(50);

            entity.HasOne(d => d.IdUserNavigation)
                .WithMany(p => p.UserRole)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.RoleNavigation)
                .WithMany(p => p.UserRole)
                .HasForeignKey(d => d.Role)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
