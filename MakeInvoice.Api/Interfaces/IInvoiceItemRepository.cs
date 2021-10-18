using MakeInvoice.Api.Models;

namespace MakeInvoice.Api.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="InvoiceItem">The type of the nvoice item.</typeparam>
    /// <author>Alexey Bubley</author>
    /// <date>2021-10-18</date>
    public interface IInvoiceItemRepository: IBaseRepository<InvoiceItem>
    {

    }
}
