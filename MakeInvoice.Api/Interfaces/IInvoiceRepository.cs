using MakeInvoice.Api.Models;

namespace MakeInvoice.Api.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="Invoice">The type of the nvoice.</typeparam>
    /// <author>Alexey Bubley</author>
    /// <date>2021-10-18</date>
    public interface IInvoiceRepository: IBaseRepository<Invoice>
    {

    }
}
