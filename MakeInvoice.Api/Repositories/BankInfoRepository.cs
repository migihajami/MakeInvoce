﻿using MakeInvoice.Api.Interfaces;
using MakeInvoice.Api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task Create(BankInfo item)
        {
            await _db.BankInfos.AddAsync(item);
            await _db.SaveChangesAsync();
        }

        public async Task Delete(BankInfo item)
        {
            var bankInfo = await _db.BankInfos.FindAsync(item.BankInfoID);
            bankInfo.IsDeleted = true;
            await _db.SaveChangesAsync();
        }

        public async Task<BankInfo> Find(Func<BankInfo, bool> predicate)
        {
            return await _db.BankInfos.FirstOrDefaultAsync(a => predicate(a) && !a.IsDeleted);
        }

        public async Task<List<BankInfo>> FindAll(Func<BankInfo, bool> predicate = null)
        {
            return await _db.BankInfos.Where(a => predicate(a) && !a.IsDeleted).ToListAsync();
        }

        public async Task Update(BankInfo item)
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