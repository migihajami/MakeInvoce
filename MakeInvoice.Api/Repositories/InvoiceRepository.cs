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
    /// Invoice repository
    /// </summary>
    /// <author>Alexey Bubley</author>
    /// <date>2021-10-18</date>
    /// <seealso cref="MakeInvoice.Api.Interfaces.IInvoiceRepository" />
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly ApiDbContext _db;

        public InvoiceRepository(ApiDbContext db)
        {
            _db = db;
        }

        public async Task<Invoice> CreateAsync(Invoice item)
        {
            await _db.Invoices.AddAsync(item);
            await _db.SaveChangesAsync();
            return item;
        }

        public async Task DeleteAsync(Invoice item)
        {
            var invoice = await _db.Invoices.FindAsync(item.InvoiceID);
            invoice.IsDeleted = true;
            await _db.SaveChangesAsync();
        }

        public async Task<Invoice> FindAsync(Expression<Func<Invoice, bool>> expression)
        {
            return await _db.Invoices.Where(expression).FirstOrDefaultAsync(a => !a.IsDeleted);
        }

        public async Task<List<Invoice>> FindAllAsync(Expression<Func<Invoice, bool>> expression)
        {
            return await _db.Invoices.Where(expression).Where(a => !a.IsDeleted).ToListAsync();
        }

        public async Task UpdateAsync(Invoice item)
        {
            var invoice = await _db.Invoices.FindAsync(item.InvoiceID);

            invoice.CompanyID = item.CompanyID;
            invoice.ContractorID = item.ContractorID;
            invoice.Currency = item.Currency;
            invoice.DueDate = item.DueDate;
            invoice.InvoiceDate = item.InvoiceDate;
            invoice.IsDeleted = item.IsDeleted;
            invoice.Number = item.Number;
            invoice.VatApplicable = item.VatApplicable;
            invoice.VatPercentage = item.VatPercentage;

            await _db.SaveChangesAsync();
        }
    }
}
