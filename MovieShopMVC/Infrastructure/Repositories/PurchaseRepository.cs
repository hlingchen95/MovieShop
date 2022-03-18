using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using ApplicationCore.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class PurchaseRepository : EFRepository<Purchase>, IPurchaseRepository
    {
        public PurchaseRepository(MovieShopDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Purchase> GetPurchaseById(int id)
        {
            var purchase = await _dbContext.Purchases.FirstOrDefaultAsync(x => x.Id == id);
            return purchase;
        }
    }
}
