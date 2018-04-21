using Microsoft.EntityFrameworkCore;

namespace SynthenticFinancialManagerSystem.Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void AddConfiguration<TEntity>(this ModelBuilder modelBuilder, EntityTypeConfiguration<TEntity> configuration)
            where TEntity : class
        {
            configuration.Configuracion(modelBuilder.Entity<TEntity>());
        }
    }
}
