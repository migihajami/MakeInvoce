using System.Threading.Tasks;

namespace MakeInvoice.Api.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    /// <author>Alexey Bubley</author>
    /// <date>2021-10-21</date>
    public interface IEmailSender
    {
        Task SendEmailAsync(string fromAddress, string toAddress, string subject, string message);
    }
}
