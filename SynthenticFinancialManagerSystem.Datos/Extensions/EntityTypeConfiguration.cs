using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SynthenticFinancialManagerSystem.Data.Extensions
{
    public abstract class EntityTypeConfiguration<TEntity>
        where TEntity : class
    {
        public abstract void Configuracion(EntityTypeBuilder<TEntity> builder);
    }
}
