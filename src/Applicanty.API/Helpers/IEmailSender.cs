using System.Threading.Tasks;

namespace Applicanty.API.Helpers
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
