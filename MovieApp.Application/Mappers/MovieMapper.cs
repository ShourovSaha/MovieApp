using AutoMapper;
using MovieApp.Application.Commands;
using MovieApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Application.Mappers
{
    internal class MovieMapper
    {
        public static IMapper Mapper => getMapper();

        private static IMapper getMapper()
        {
            var config = new MapperConfiguration(p =>
            {
                p.AddProfile<MovieMappingProfile>();
            });

            return config.CreateMapper();
        }
    }
}
