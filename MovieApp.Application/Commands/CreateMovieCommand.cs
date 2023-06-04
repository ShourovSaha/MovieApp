using MediatR;
using MovieApp.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Application.Commands
{
    public class CreateMovieCommand : IRequest<MovieResponse>
    {
        public string Name { get; set; }
        public string DirectorName { get; set; }
        public string ReleaseYear { get; set; }
    }
}
