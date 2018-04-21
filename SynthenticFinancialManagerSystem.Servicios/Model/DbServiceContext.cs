using Microsoft.EntityFrameworkCore;
using SynthenticFinancialManagerSystem.Data.Model.Context;

namespace SynthenticFinancialManagerSystem.Services.Model
{
    public class DbServiceContext : BaseIdentityDbContext
    {
        public DbServiceContext(DbContextOptions options) : base(options)
        {
        }
    }
}
