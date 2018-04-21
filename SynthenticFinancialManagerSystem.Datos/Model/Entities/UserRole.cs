namespace SynthenticFinancialManagerSystem.Data.Model.Entities
{
    public partial class UserRole : EntityControl
    {
        public int IdUser { get; set; }
        public string Role { get; set; }
        
        public User IdUserNavigation { get; set; }
        public Role RoleNavigation { get; set; }
    }
}
