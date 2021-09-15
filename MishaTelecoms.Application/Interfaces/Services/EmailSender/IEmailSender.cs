using System.Threading.Tasks;

namespace MishaTelecoms.Application.Interfaces.Services.EmailSender
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
