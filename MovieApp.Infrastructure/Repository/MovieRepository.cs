using Microsoft.EntityFrameworkCore;
using MovieApp.Core.Entities;
using MovieApp.Core.Entities.Base;
using MovieApp.Core.Repositories;
using MovieApp.Core.Repositories.Base;
using MovieApp.Infrastructure.Data;
using MovieApp.Infrastructure.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Infrastructure.Repository
{
    public class MovieRepository : Repository<Movie>, IMovieRepository
    {
        public MovieRepository(MovieDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Movie>> GetAllByDirectorName(string directorName)
        {
            return await _dbContext.Movies.Where(p => p.DirectorName == directorName).ToListAsync();
        }
    }
}
