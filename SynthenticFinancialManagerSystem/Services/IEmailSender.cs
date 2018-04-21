using System.Threading.Tasks;

namespace SynthenticFinancialManagerSystem.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
