using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MovieApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Infrastructure.Data
{
    public interface IDbContextSeed
    {
        Task SeedAsync();
    }

    public class MovieDbContextSeed : IDbContextSeed
    {
        private readonly MovieDbContext _context;
        public MovieDbContextSeed(MovieDbContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            int retryForAvailability = 0;

            try
            {
                if (!await _context.Movies.AnyAsync<Movie>())
                {
                    _context.Movies.AddRange(getMovies());
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                if (retryForAvailability < 3)
                {
                    ++retryForAvailability;
                    await SeedAsync();
                }
            }
        }

        private Movie[] getMovies()
        {
            return new Movie[]
            {
                new Movie(){Name = "RRR", DirectorName = "Ramcharan", ReleaseYear = "2022"},
                new Movie(){Name = "Avater", DirectorName = "James Cameroon", ReleaseYear = "2012"},
                new Movie(){Name = "Batman - The Dark knight", DirectorName = "Cristofer Nonal", ReleaseYear = "2008"}
            };
        }
    }


    internal class MovieDbContextSeed1
    {
        public async Task SeedDataAsync(MovieDbContext dbContext, ILoggerFactory loggerFactory, int? retry = 0)
        {
            int retryForAvailability = retry.Value;

            try
            {
                if (!await dbContext.Movies.AnyAsync<Movie>())
                {
                    dbContext.Movies.AddRange(getMovies());
                    await dbContext.SaveChangesAsync();
                }
            }
            catch(Exception ex)
            {
                if(retryForAvailability < 3)
                {
                    ++retryForAvailability;
                    var log = loggerFactory.CreateLogger<MovieDbContextSeed>();
                    log.LogError(message: $"Exception occurred while connecting : {ex.Message}");
                    await SeedDataAsync(dbContext, loggerFactory, retry);
                }
            }
        }

        private Movie[] getMovies()
        {
            return new Movie[]
            {
                new Movie(){Name = "RRR", DirectorName = "Ramcharan", ReleaseYear = "2022"},
                new Movie(){Name = "Avater", DirectorName = "James Cameroon", ReleaseYear = "2012"},
                new Movie(){Name = "Batman - The Dark knight", DirectorName = "Cristofer Nonal", ReleaseYear = "2008"}
            };
        }
    }
}
