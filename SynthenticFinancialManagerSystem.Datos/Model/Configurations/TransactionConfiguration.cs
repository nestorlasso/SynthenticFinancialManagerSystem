using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SynthenticFinancialManagerSystem.Data.Model.Entities;
using SynthenticFinancialManagerSystem.Data.Extensions;

namespace SynthenticFinancialManagerSystem.Data.Model.Configurations
{
    public class TransactionConfiguration : EntityTypeConfiguration<Transaction>
    {
        public override void Configuracion(EntityTypeBuilder<Transaction> entity)
        {
            entity.HasKey(e => e.IdTransaction);

            entity.ToTable("Transaction", "financialmanager");

            entity.Property(e => e.Type).HasMaxLength(20);

            entity.Property(e => e.Amount).HasColumnType("decimal(10,3)");

            entity.Property(e => e.NameDest).HasMaxLength(30);

            entity.Property(e => e.NameOrig).HasMaxLength(30);

            entity.Property(e => e.IsFraud).HasDefaultValue(false);

            entity.Property(e => e.TransactionDate).HasColumnType("date");
        }
    }
}
