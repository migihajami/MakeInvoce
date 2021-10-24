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
    /// Contractor Repository
    /// </summary>
    /// <author>Alexey Bubley</author>
    /// <date>2021-10-18</date>
    /// <seealso cref="MakeInvoice.Api.Interfaces.IContractorRepository" />
    public class ContractorRepository : IContractorRepository
    {
        private readonly ApiDbContext _db;

        public ContractorRepository(ApiDbContext db)
        {
            _db = db;
        }

        public async Task<Contractor> CreateAsync(Contractor item)
        {
            await _db.Contractors.AddAsync(item);
            await _db.SaveChangesAsync();
            return item;
        }

        public async Task DeleteAsync(Contractor item)
        {
            var contractor = await _db.Contractors.FindAsync(item.ID);
            contractor.IsDeleted = true;
            contractor.IsActive = false;
            await _db.SaveChangesAsync();
        }

        public async Task<Contractor> FindAsync(Expression<Func<Contractor, bool>> expression)
        {
            return await _db.Contractors.Where(expression).FirstOrDefaultAsync(a => !a.IsDeleted);
        }

        public async Task<List<Contractor>> FindAllAsync(Expression<Func<Contractor, bool>> expression)
        {
            return await _db.Contractors.Where(expression).Where(a => !a.IsDeleted).ToListAsync();
        }

        public async Task UpdateAsync(Contractor item)
        {
            var contractor = await _db.Contractors.FindAsync(item.ID);

            contractor.Description = item.Description;
            contractor.EmailAddress = item.EmailAddress;
            contractor.IsActive = item.IsActive;
            contractor.IsDeleted = item.IsDeleted;
            contractor.LegalAddressID = item.LegalAddressID;
            contractor.LegalName = item.LegalName;
            contractor.Name = item.Name;
            contractor.OwnerID = item.OwnerID;
            contractor.PhoneNumber = item.PhoneNumber;
            contractor.PostalAddressID = item.PostalAddressID;
            contractor.RegNumber = item.RegNumber;
            contractor.VatNumber = item.VatNumber;

            await _db.SaveChangesAsync();
        }
    }
}
