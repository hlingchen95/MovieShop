using ApplicationCore.Contracts.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MovieShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private IMovieService _movieServivce;

        public MoviesController(IMovieService movieServivce)
        {
            _movieServivce = movieServivce;
        }

        [Route("{id:int}")]
        [HttpGet]
        public async Task<IActionResult> GetMovie(int id)
        {
            var movie = await _movieServivce.GetMovieDetails(id);

            if (movie == null)
            {
                return NotFound( new { error = $"Movie Not Found for id: {id}"});
            }
            return Ok(movie);


        }

        [Route("top-grossing")]
        [HttpGet]
        public async Task<IActionResult> GetTopGrossingMovie()
        {
            var topGrossingMovie = await _movieServivce.GetTop30GrossingMovies();
            if (topGrossingMovie == null)
            {
                return NotFound(new { error = $"Movie Not Found for id: " });
            }
            return Ok(topGrossingMovie);
        }

        [Route("")]
        [HttpGet]
        public async Task<IActionResult> PagedMovie()
        {
            var pagedMovies = await _movieServivce.GetTop30GrossingMovies();
            if (pagedMovies == null)
            {
                return NotFound();
            }
            return Ok(pagedMovies);
        }

        [Route("genre/{genreId:int}")]
        [HttpGet]
        public async Task<IActionResult> Genre(int genreId)
        {
            var movies = await _movieServivce.GetMoviesByGenrePagination(genreId);
            if (movies == null)
            {
                return BadRequest();
            }
            return Ok(movies);
        }
    }
}
