﻿using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using MovieShopMVC.Models;
using System.Diagnostics;

namespace MovieShopMVC.Controllers
{
    public class HomeController : Controller
    {
        
        [HttpGet]
        public IActionResult Index()
        {
            var movieService = new MovieService();
            var movies = movieService.GetTop30GrossingMovies();

            return View(movies);
        }

        [HttpGet]
        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult TopMovies()
        {  
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}