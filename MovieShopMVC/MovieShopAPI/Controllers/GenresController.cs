using ApplicationCore.Contracts.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MovieShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private IGenreService _genreServivce;

        public GenresController(IGenreService genreServivce)
        {
            _genreServivce = genreServivce;
        }

        [Route("")]
        [HttpGet]
        public async Task<IActionResult> allGenre()
        {
            var pagedMovies = await _genreServivce.GetAllGenres();
            if (pagedMovies == null)
            {
                return NotFound();
            }
            return Ok(pagedMovies);
        }
    }
}
