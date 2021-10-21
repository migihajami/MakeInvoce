using MakeInvoice.Api.Interfaces;
using MakeInvoice.Api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task Create(InvoiceItem item)
        {
            await _db.InvoiceItems.AddAsync(item);
            await _db.SaveChangesAsync();
        }

        public async Task Delete(InvoiceItem item)
        {
            var invoiceItem = await _db.InvoiceItems.FindAsync(item.InvoiceItemID);
            invoiceItem.IsDeleted = true;
            await _db.SaveChangesAsync();
        }

        public async Task<InvoiceItem> Find(Func<InvoiceItem, bool> predicate)
        {
            return await _db.InvoiceItems.FirstOrDefaultAsync(a => predicate(a) && !a.IsDeleted);
        }

        public async Task<List<InvoiceItem>> FindAll(Func<InvoiceItem, bool> predicate = null)
        {
            return await _db.InvoiceItems.Where(a => predicate(a) && !a.IsDeleted).ToListAsync();
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
