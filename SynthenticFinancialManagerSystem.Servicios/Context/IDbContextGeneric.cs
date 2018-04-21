using SynthenticFinancialManagerSystem.Services.Model;

namespace SynthenticFinancialManagerSystem.Services.Context
{
    public interface IDbContextGeneric
    {
        DbServiceContext GetContext();
    }
}
