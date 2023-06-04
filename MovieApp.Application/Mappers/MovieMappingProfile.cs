using AutoMapper;
using MovieApp.Application.Commands;
using MovieApp.Application.Queries;
using MovieApp.Application.Responses;
using MovieApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Application.Mappers
{
    public class MovieMappingProfile : Profile
    {
        public MovieMappingProfile()
        {
            CreateMap<Movie, CreateMovieCommand>().ReverseMap();
            CreateMap<Movie, MovieResponse>().ReverseMap();
        }
    }
}
