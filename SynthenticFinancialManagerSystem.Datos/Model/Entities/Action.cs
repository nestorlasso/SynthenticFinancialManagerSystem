using System.Collections.Generic;

namespace SynthenticFinancialManagerSystem.Data.Model.Entities
{
    public partial class Action
    {
        public Action()
        {
            ActionRole = new HashSet<ActionRole>();
        }

        public int IdAction { get; set; }
        public string ActionName { get; set; }
        
        public ICollection<ActionRole> ActionRole { get; set; }
    }
}
