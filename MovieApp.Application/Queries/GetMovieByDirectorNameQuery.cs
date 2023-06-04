using MediatR;
using MovieApp.Application.Responses;
using MovieApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Application.Queries
{
    public class GetMovieByDirectorNameQuery : IRequest<IEnumerable<MovieResponse>>
    {
        public string DirectorName { get; set; }
        public GetMovieByDirectorNameQuery(string directorName)
        {
            this.DirectorName = directorName;
        }
    }
}
