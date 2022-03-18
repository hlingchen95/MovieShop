using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPurchaseRepository _purchaseRepository;

        public UserService(IUserRepository userRepository, IPurchaseRepository purchaseRepository)
        {
            _userRepository = userRepository;
            _purchaseRepository = purchaseRepository;
        }
        public Task AddFavorite(FavoriteRequestModel favoriteRequest)
        {
            throw new NotImplementedException();
        }

        public Task AddMovieReview(ReviewRequestModel reviewRequest)
        {
            throw new NotImplementedException();
        }

        public Task DeleteMovieReview(int userId, int movieId)
        {
            throw new NotImplementedException();
        }

        public Task FavoriteExists(int id, int movieId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<FavoriteRequestModel>> GetAllFavoritesForUser(int id)
        {
            var favorites = await _userRepository.GetFavoritesByUserId(id);

            var favoritesModel = favorites.Select(g => new FavoriteRequestModel
            {              
                UserId = g.UserId,
                MovieId = g.MovieId,
            }).ToList();
            return favoritesModel;
        }

        public async Task<List<PurchaseRequestModel>> GetAllPurchasesForUser(int id)
        {
            var purchased = await _userRepository.GetPurchaseByUserId(id);

            var purchaseModel = purchased.Select(g => new PurchaseRequestModel
            {
                Id = g.Id,
                UserId = g.UserId,
                MovieId = g.MovieId,
                PurchaseNumber = g.PurchaseNumber,
                TotalPrice = g.TotalPrice,
                PurchaseDateTime = g.PurchaseDateTime,

            }).ToList();
            return purchaseModel;
        }

        public Task GetAllReviewsByUser(int id)
        {
            throw new NotImplementedException();
        }

        public Task GetPurchasesDetails(int userId, int movieId)
        {
            throw new NotImplementedException();
        }

        public Task IsMoviePurchased(PurchaseRequestModel purchaseRequest, int userId)
        {
            throw new NotImplementedException();
        }

        public async Task<PurchaseRequestModel> PurchaseMovie(PurchaseRequestModel purchaseRequest, int userId)
        {
            var purchase = new Purchase
            {
                UserId = userId,
                MovieId = purchaseRequest.MovieId,
                PurchaseNumber = purchaseRequest.PurchaseNumber,
                TotalPrice = purchaseRequest.TotalPrice,
                PurchaseDateTime = purchaseRequest.PurchaseDateTime,

            };
            var moviePurchase = await _userRepository.AddPurchase(purchase);
            return purchaseRequest;

        }

        public Task RemoveFavorite(FavoriteRequestModel favoriteRequest)
        {
            throw new NotImplementedException();
        }

        public Task UpdateMovieReview(ReviewRequestModel reviewRequest)
        {
            throw new NotImplementedException();
        }
    }
}
