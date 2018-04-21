using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SynthenticFinancialManagerSystem.Data.Model.Entities;
using SynthenticFinancialManagerSystem.Data.Extensions;

namespace SynthenticFinancialManagerSystem.Data.Model.Configurations
{
    public class ActionConfiguration : EntityTypeConfiguration<Action>
    {
        public override void Configuracion(EntityTypeBuilder<Action> entity)
        {
            entity.HasKey(e => e.IdAction);

            entity.ToTable("Action", "base");

            entity.HasIndex(e => new { e.ActionName }).IsUnique();

            entity.Property(e => e.IdAction).ValueGeneratedNever();

            entity.Property(e => e.ActionName).IsRequired().HasMaxLength(50);
        }
    }
}
