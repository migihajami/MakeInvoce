using MakeInvoice.Api.Interfaces;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace MakeInvoice.Api.Utils
{
    /// <summary>
    /// SMTP Email Sender
    /// </summary>
    /// <author>Alexey Bubley</author>
    /// <date>2021-10-21</date>
    /// <seealso cref="MakeInvoice.Api.Interfaces.IEmailSender" />
    public class SmtpEmailSender : IEmailSender
    {
        private readonly SmtpOptions options;

        public SmtpEmailSender(IOptions<SmtpOptions> options)
        {
            this.options = options.Value;
        }

        public async Task SendEmailAsync(string from, string to, string subject, string message)
        {
            var mailMessage = new MailMessage(from, to, subject, message);
            using (var smtpClient = new SmtpClient(options.Host, options.Port))
            {
                smtpClient.Credentials = new NetworkCredential(options.Username, options.Password);
                await smtpClient.SendMailAsync(mailMessage);
            }
        }

        public async Task SendEmailAsync(string to, string subject, string message)
        {
            await SendEmailAsync(options.NoreplyAddress, to, subject, message);
        }
    }
}
