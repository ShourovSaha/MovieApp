using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieApp.Application.Commands;
using MovieApp.Application.Queries;
using MovieApp.Application.Responses;
using System;
using System.Collections.Generic;

namespace MovieApp.API.ApiControllers
{
    public class MoviesController : ApiController
    {
        private IMediator _mediator;
        public MoviesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<MovieResponse>>> GetMoviesByDirectorName(string directorName)
        {
            IEnumerable<MovieResponse> movies;
            try
            {
                movies = await _mediator.Send(new GetMovieByDirectorNameQuery(directorName));
            }
            catch (Exception)
            {
                throw;
            }
            return Ok(movies);
        }

        [HttpPost]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        public async Task<ActionResult<MovieResponse>> CreateMovie(CreateMovieCommand movieCommand)
        {
            MovieResponse movie;
            try
            {
                movie = await _mediator.Send(movieCommand);
            }
            catch (Exception)
            {
                throw;
            }
            return Ok(movie);
        }
    }
}
