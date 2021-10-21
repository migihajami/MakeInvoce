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
    /// Company Repository
    /// </summary>
    /// <author>Alexey Bubley</author>
    /// <date>2021-10-18</date>
    /// <seealso cref="MakeInvoice.Api.Interfaces.ICompanyRepository" />
    public class CompanyRepository : ICompanyRepository
    {
        private readonly ApiDbContext _db;

        public CompanyRepository(ApiDbContext db)
        {
            _db = db;
        }
        public async Task Create(Company item)
        {
            await _db.Companies.AddAsync(item);
            await _db.SaveChangesAsync();
        }

        public async Task Delete(Company item)
        {
            var company = await _db.Companies.FindAsync(item.ID);
            company.IsDeleted = true;
            company.IsActive = false;
            await _db.SaveChangesAsync();
        }

        public async Task<Company> Find(Func<Company, bool> predicate)
        {
            return await _db.Companies.FirstOrDefaultAsync(a => predicate(a) && !a.IsDeleted);
        }

        public async Task<List<Company>> FindAll(Func<Company, bool> predicate = null)
        {
            return await _db.Companies.Where(a => predicate(a) && !a.IsDeleted).ToListAsync();
        }

        public async Task Update(Company item)
        {
            var company = await _db.Companies.FindAsync(item.ID);
            
            company.EmailAddress = item.EmailAddress;
            company.IsActive = item.IsActive;
            company.IsDeleted = item.IsDeleted;
            company.LegalAddressID = item.LegalAddressID;
            company.LegalName = item.LegalName;
            company.OwnerID = item.OwnerID;
            company.PhoneNumber = item.PhoneNumber;
            company.PostalAddressID = item.PostalAddressID;
            company.RegNumber = item.RegNumber;
            company.VatNumber = item.VatNumber;

            await _db.SaveChangesAsync();
        }
    }
}
