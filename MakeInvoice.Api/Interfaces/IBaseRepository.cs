using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MakeInvoice.Api.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <author>Alexey Bubley</author>
    /// <date>2021-10-18</date>
    public interface IBaseRepository<T> where T: class
    {
        Task Create(T item);
        Task Update(T item);
        Task Delete(T item);
        Task<T> Find(Func<T, bool> predicate);
        Task<IList<T>> FindAll(Func<T, bool> predicate = null);
    }
}
