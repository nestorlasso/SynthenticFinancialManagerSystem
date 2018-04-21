using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace SynthenticFinancialManagerSystem.Data.Model.Entities
{
    public partial class User : IdentityUser<int>
    {
        public User()
        {
            UserRole = new HashSet<UserRole>();
        }        
        
        public ICollection<UserRole> UserRole { get; set; }
    }
}
