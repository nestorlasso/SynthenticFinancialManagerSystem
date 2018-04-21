namespace SynthenticFinancialManagerSystem.Data.Model.Entities
{
    public partial class ActionRole : EntityControl
    {
        public string Role { get; set; }
        public int IdAction { get; set; }

        public Action IdActionNavigation { get; set; }
        public Role RoleNavigation { get; set; }
    }
}
