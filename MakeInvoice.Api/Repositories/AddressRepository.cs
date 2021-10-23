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
    /// Address Repository
    /// </summary>
    /// <author>Alexey Bubley</author>
    /// <date>2021-10-18</date>
    /// <seealso cref="MakeInvoice.Api.Interfaces.IAddressRepository" />
    public class AddressRepository : IAddressRepository
    {
        private readonly ApiDbContext _db;

        public AddressRepository(ApiDbContext db)
        {
            _db = db;
        }

        public async Task Create(Address item)
        {
            await _db.Addresses.AddAsync(item);
            await _db.SaveChangesAsync();
        }

        public async Task Delete(Address item)
        {
            var address = await _db.Addresses.FindAsync(item.AddressID);
            address.IsDeleted = true;
            await _db.SaveChangesAsync();
        }

        public async Task<Address> Find(Expression<Func<Address, bool>> expression)
        {
            return await _db.Addresses.Where(expression).FirstOrDefaultAsync(a => !a.IsDeleted);
        }

        public async Task<List<Address>> FindAll(Expression<Func<Address, bool>> expression = null)
        {
            return await _db.Addresses.Where(expression).Where(a => !a.IsDeleted).ToListAsync();
        }

        public async Task Update(Address item)
        {
            var address = await _db.Addresses.FindAsync(item.AddressID);

            address.City = item.City;
            address.Country = item.Country;
            address.IsDeleted = item.IsDeleted;
            address.Line1 = item.Line1;
            address.Line2 = item.Line2;
            address.PostalCode = item.PostalCode;

            await _db.SaveChangesAsync();
        }
    }
}
