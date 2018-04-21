using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SynthenticFinancialManagerSystem.Data.Model.Entities;
using SynthenticFinancialManagerSystem.Data.Extensions;

namespace SynthenticFinancialManagerSystem.Data.Model.Configurations
{
    public class RoleConfiguration : EntityTypeConfiguration<Role>
    {
        public override void Configuracion(EntityTypeBuilder<Role> entity)
        {
            entity.HasKey(e => e.RoleName);

            entity.ToTable("Role", "base");

            entity.Property(e => e.RoleName).HasMaxLength(50);

            entity.Property(e => e.UpdateBy).HasMaxLength(50);

            entity.Property(e => e.Active).HasDefaultValue(true);

            entity.Property(e => e.CreateBy).IsRequired().HasMaxLength(50);
        }
    }
}
