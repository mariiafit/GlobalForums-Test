using System.Threading.Tasks;

namespace GlobalForums.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
