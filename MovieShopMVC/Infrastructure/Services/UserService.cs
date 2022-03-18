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

        public Task GetAllFavoritesForUser(int id)
        {
            throw new NotImplementedException();
        }

        public Task GetAllPurchasesForUser(int id)
        {
            throw new NotImplementedException();
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
            //var moviePurchase = await _purchaseRepository.;
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
