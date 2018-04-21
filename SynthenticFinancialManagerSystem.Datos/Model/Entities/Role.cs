using System.Collections.Generic;

namespace SynthenticFinancialManagerSystem.Data.Model.Entities
{
    public partial class Role : EntityControl
    {
        public Role()
        {
            ActionRole = new HashSet<ActionRole>();
            UserRole = new HashSet<UserRole>();
        }

        public string RoleName { get; set; }
        
        public ICollection<ActionRole> ActionRole { get; set; }
        public ICollection<UserRole> UserRole { get; set; }
    }
}
