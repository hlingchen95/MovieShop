using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieShopMVC.Services;
using System.Security.Claims;

namespace MovieShopMVC.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly ICurrentUser _currentUser;
        private readonly IUserService _userService;
        private readonly IMovieService _movieService;

        public UserController(ICurrentUser currentUser, IUserService userService, IMovieService movieService)
        {
            _currentUser = currentUser;
            _userService = userService;
            _movieService = movieService;
        }

        [HttpGet]
        public async Task<IActionResult> Purchases()
        {
            
            var userId = _currentUser.UserId;
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Favorites()
        {
            var userId = _currentUser.UserId;
            //var favoritesList = await _userService.GetAllFavoritesForUser(userId);
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Reviews()
        {
            var userId = _currentUser.UserId;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> BuyMovie(int movieId)
        {
            var userId = _currentUser.UserId;
            var moviePrice = await _movieService.GetMoviePrice(userId);

            var purchaseRequest = new PurchaseRequestModel
            {
                UserId = userId,
                MovieId = movieId,
                PurchaseNumber = Guid.NewGuid(),
                TotalPrice = moviePrice,
                PurchaseDateTime = DateTime.UtcNow,
            };
            var purchase = await _userService.PurchaseMovie(purchaseRequest, userId);
            return View("Purchases");
        }

        [HttpPost]
        public async Task<IActionResult> FavoriteMovie()
        {
            var userId = _currentUser.UserId;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ReviewMovie()
        {
            return View();
        }
    }
}
