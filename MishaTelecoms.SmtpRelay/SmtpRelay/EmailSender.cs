using MishaTelecoms.Application.Interfaces.Services.EmailSender;
using System;
using System.Threading.Tasks;

namespace MishaTelecoms.SmtpRelay.SmtpRelay
{
    public class EmailSender : IEmailSender
    {
        public async Task SendEmailAsync(string email, string subject, string message)
        {
            throw new NotImplementedException();
        }
    }
}
