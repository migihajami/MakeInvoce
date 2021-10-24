using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
        Task<T> Create(T item);
        Task Update(T item);
        Task Delete(T item);
        Task<T> Find(Expression<Func<T, bool>> expression);
        Task<List<T>> FindAll(Expression<Func<T, bool>> expression = null);
    }
}
