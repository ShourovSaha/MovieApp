using MediatR;
using MovieApp.Application.Mappers;
using MovieApp.Application.Queries;
using MovieApp.Application.Responses;
using MovieApp.Core.Entities;
using MovieApp.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Application.Handlers
{
    public class GetMovieByDirectorNameQueryHandler : IRequestHandler<GetMovieByDirectorNameQuery, IEnumerable<MovieResponse>>
    {
        private readonly IMovieRepository _movieRepository;
        public GetMovieByDirectorNameQueryHandler(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<IEnumerable<MovieResponse>> Handle(GetMovieByDirectorNameQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<Movie> movies = await _movieRepository.GetAllByDirectorName(request.DirectorName);
            var moviesResponse = MovieMapper.Mapper.Map<IEnumerable<MovieResponse>>(movies);
            return moviesResponse;
        }
    }
}
