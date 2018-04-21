using System.ComponentModel.DataAnnotations;

namespace SynthenticFinancialManagerSystem.Models.AccountViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
