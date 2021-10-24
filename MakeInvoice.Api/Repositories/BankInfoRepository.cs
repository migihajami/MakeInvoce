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
    /// Bank Info Repository
    /// </summary>
    /// <author>Alexey Bubley</author>
    /// <date>2021-10-18</date>
    /// <seealso cref="MakeInvoice.Api.Interfaces.IBankInfoRepository" />
    public class BankInfoRepository : IBankInfoRepository
    {
        private readonly ApiDbContext _db;

        public BankInfoRepository(ApiDbContext db)
        {
            _db = db;
        }

        public async Task<BankInfo> CreateAsync(BankInfo item)
        {
            await _db.BankInfos.AddAsync(item);
            await _db.SaveChangesAsync();
            return item;
        }

        public async Task DeleteAsync(BankInfo item)
        {
            var bankInfo = await _db.BankInfos.FindAsync(item.BankInfoID);
            bankInfo.IsDeleted = true;
            await _db.SaveChangesAsync();
        }

        public async Task<BankInfo> FindAsync(Expression<Func<BankInfo, bool>> expression)
        {
            return await _db.BankInfos.Where(expression).FirstOrDefaultAsync(a => !a.IsDeleted);
        }

        public async Task<List<BankInfo>> FindAllAsync(Expression<Func<BankInfo, bool>> expression = null)
        {
            return await _db.BankInfos.Where(expression).Where(a => !a.IsDeleted).ToListAsync();
        }

        public async Task UpdateAsync(BankInfo item)
        {
            var bankInfo = await _db.BankInfos.FindAsync(item.BankInfoID);
            bankInfo.AccountNumber = item.AccountNumber;
            bankInfo.BankAddressID = item.BankAddressID;
            bankInfo.BankName = item.BankName;
            bankInfo.IsDeleted = item.IsDeleted;
            bankInfo.Swift = item.Swift;

            await _db.SaveChangesAsync();
        }
    }
}
