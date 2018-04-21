using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SynthenticFinancialManagerSystem.Data.Model.Entities;
using SynthenticFinancialManagerSystem.Data.Extensions;

namespace SynthenticFinancialManagerSystem.Data.Model.Configurations
{
    public class UserConfiguration : EntityTypeConfiguration<User>
    {
        public override void Configuracion(EntityTypeBuilder<User> entity)
        {
            entity.HasKey(e => e.Id);

            entity.ToTable("User", "base");

            entity.HasDiscriminator().HasValue("Usuario");            

            entity.Property(e => e.UserName).IsRequired().HasMaxLength(50);
        }
    }
}
