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
        Task<T> CreateAsync(T item);
        Task UpdateAsync(T item);
        Task DeleteAsync(T item);
        Task<T> FindAsync(Expression<Func<T, bool>> expression);
        Task<List<T>> FindAllAsync(Expression<Func<T, bool>> expression = null);
    }
}
