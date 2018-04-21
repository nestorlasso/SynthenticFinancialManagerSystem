using Microsoft.AspNetCore.Identity;

namespace SynthenticFinancialManagerSystem.Data.Model.Entities
{
    public class ApplicationRole : IdentityRole<int>
    {
        public ApplicationRole() : base()
        {
        }

        public ApplicationRole(string roleName)
        {
            Name = roleName;
        }
    }
}
