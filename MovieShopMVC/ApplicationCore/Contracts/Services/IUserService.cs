﻿using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Contracts.Services
{
    public interface IUserService
    {
        
        Task<PurchaseRequestModel> PurchaseMovie(PurchaseRequestModel purchaseRequest, int userId);
        Task IsMoviePurchased(PurchaseRequestModel purchaseRequest, int userId);
        Task<List<PurchaseRequestModel>> GetAllPurchasesForUser(int id);
        Task GetPurchasesDetails(int userId, int movieId);
        Task AddFavorite(FavoriteRequestModel favoriteRequest);
        Task RemoveFavorite(FavoriteRequestModel favoriteRequest);
        Task FavoriteExists(int id, int movieId);
        Task<List<FavoriteRequestModel>> GetAllFavoritesForUser(int id);
        Task AddMovieReview(ReviewRequestModel reviewRequest);
        Task UpdateMovieReview(ReviewRequestModel reviewRequest);
        Task DeleteMovieReview(int userId, int movieId);
        Task GetAllReviewsByUser(int id);

    }
}
