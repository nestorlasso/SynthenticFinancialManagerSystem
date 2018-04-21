using SynthenticFinancialManagerSystem.Services.Model;

namespace SynthenticFinancialManagerSystem.Services.Context
{
    public class DbContextGeneric :  IDbContextGeneric
    {
        private readonly DbServiceContext _context;

        public DbContextGeneric(DbServiceContext context)
        {
            _context = context;
        }

        public DbServiceContext GetContext()
        {
            return _context;
        }
    }
}
