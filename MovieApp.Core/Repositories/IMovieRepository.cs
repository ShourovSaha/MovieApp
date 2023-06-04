using MovieApp.Core.Entities;
using MovieApp.Core.Entities.Base;
using MovieApp.Core.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Core.Repositories
{
    public interface IMovieRepository : IRepository<Movie>
    {
        Task<IEnumerable<Movie>> GetAllByDirectorName(string directorName);
    }
}
