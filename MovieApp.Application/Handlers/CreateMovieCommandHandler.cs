using MediatR;
using MovieApp.Application.Commands;
using MovieApp.Application.Mappers;
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
    public class CreateMovieCommandHandler : IRequestHandler<CreateMovieCommand, MovieResponse>
    {
        private readonly IMovieRepository _movieRepository;
        public CreateMovieCommandHandler(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }
        public async Task<MovieResponse> Handle(CreateMovieCommand request, CancellationToken cancellationToken)
        {
            Movie movieEntity = MovieMapper.Mapper.Map<Movie>(request);

            if (movieEntity is null)
                throw new ApplicationException(message: "Object mapping issue remaining.");

            Movie newMovie = await _movieRepository.CreateAsync(movieEntity);
            MovieResponse movieResponse = MovieMapper.Mapper.Map<MovieResponse>(newMovie);
            return movieResponse;
        }
    }
}
