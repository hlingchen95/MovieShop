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
    public class MovieRepository : EFRepository<Movie>, IMovieRepository
    {
        public MovieRepository(MovieShopDbContext dbContext) : base(dbContext)
        {

        }

        IEnumerable<Movie> IMovieRepository.GetTop30RevenueMovies()
        {
            var movies = _dbContext.Movies.OrderByDescending(m => m.Revenue).Take(30);
            return movies;
        }
    }
}
