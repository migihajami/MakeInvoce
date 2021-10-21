namespace MakeInvoice.Api.Utils
{
    /// <summary>
    /// SMTP Options
    /// </summary>
    /// <author>Alexey Bubley</author>
    /// <date>2021-10-21</date>
    public class SmtpOptions
    {
        public string Host { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int Port { get; set; }
    }
}
