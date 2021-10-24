using MakeInvoice.Api.Interfaces;
using MakeInvoice.Api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MakeInvoice.Api.Repositories
{
    /// <summary>
    /// Invoice item repository
    /// </summary>
    /// <author>Alexey Bubley</author>
    /// <date>2021-10-18</date>
    /// <seealso cref="MakeInvoice.Api.Interfaces.IInvoiceItemRepository" />
    public class InvoiceItemRepository : IInvoiceItemRepository
    {
        private readonly ApiDbContext _db;

        public InvoiceItemRepository(ApiDbContext db)
        {
            _db = db;
        }

        public async Task<InvoiceItem> Create(InvoiceItem item)
        {
            await _db.InvoiceItems.AddAsync(item);
            await _db.SaveChangesAsync();
            return item;
        }

        public async Task Delete(InvoiceItem item)
        {
            var invoiceItem = await _db.InvoiceItems.FindAsync(item.InvoiceItemID);
            invoiceItem.IsDeleted = true;
            await _db.SaveChangesAsync();
        }

        public async Task<InvoiceItem> Find(Expression<Func<InvoiceItem, bool>> expression)
        {
            return await _db.InvoiceItems.Where(expression).FirstOrDefaultAsync(a => !a.IsDeleted);
        }

        public async Task<List<InvoiceItem>> FindAll(Expression<Func<InvoiceItem, bool>> expression = null)
        {
            return await _db.InvoiceItems.Where(expression).Where(a => !a.IsDeleted).ToListAsync();
        }

        public async Task Update(InvoiceItem item)
        {
            var invoiceItem = await _db.InvoiceItems.FindAsync(item.InvoiceItemID);

            invoiceItem.Info = item.Info;
            invoiceItem.InvoiceID = item.InvoiceID;
            invoiceItem.IsDeleted = item.IsDeleted;
            invoiceItem.Name = item.Name;
            invoiceItem.UnitCount = item.UnitCount;
            invoiceItem.UnitPrice = item.UnitPrice;
            invoiceItem.UnitType = item.UnitType;

            await _db.SaveChangesAsync();
        }
    }
}
