using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class UserRepository : EFRepository<User>, IUserRepository
    {
        public UserRepository(MovieShopDbContext dbContext) : base(dbContext)
        {
        }
        public async Task<List<Purchase>> GetPurchaseByUserId(int id)
        {
            var purchase = await _dbContext.Purchases.Where(p => p.UserId == id).ToListAsync(); 
            return purchase;
        }

        public async Task<List<Favorite>> GetFavoritesByUserId(int id)
        {
            var favorites = await _dbContext.Favorites.Where(p => p.UserId == id).ToListAsync();
            return favorites;
        }

        public async Task<Purchase> AddPurchase(Purchase purchase)
        {
            _dbContext.Set<Purchase>().Add(purchase);
            await _dbContext.SaveChangesAsync();
            return purchase;
        }




        

        public async Task<User> GetUserByEmail(string email)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Email == email);
            return user;
        }

       
    }
}
