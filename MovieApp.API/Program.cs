using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using MovieApp.Application.Handlers;
using MovieApp.Application.Queries;
using MovieApp.Application.Responses;
using MovieApp.Core.Repositories;
using MovieApp.Core.Repositories.Base;
using MovieApp.Infrastructure.Data;
using MovieApp.Infrastructure.Repository;
using MovieApp.Infrastructure.Repository.Base;
using System.Reflection;

namespace MovieApp.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddDbContext<MovieDbContext>(
                    options => options.UseSqlServer(connectionString: builder.Configuration.GetConnectionString("MovieDBConnection"))
                    , ServiceLifetime.Singleton
                );
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            builder.Services.AddMediatR(a => a.RegisterServicesFromAssemblyContaining<Program>());
            builder.Services.AddTransient<IRequestHandler<GetMovieByDirectorNameQuery, IEnumerable<MovieResponse>>, GetMovieByDirectorNameQueryHandler>();
            builder.Services.AddSingleton<IDbContextSeed, MovieDbContextSeed>();
            builder.Services.Configure<MovieDbContextSeed>(async config => await config.SeedAsync());
            builder.Services.AddScoped(serviceType: typeof(IRepository<>), typeof(Repository<>));
            builder.Services.AddTransient<IMovieRepository, MovieRepository>();
            builder.Services.AddSwaggerGen(
                p =>
                {
                    p.SwaggerDoc(
                        name: "v1",
                        new OpenApiInfo()
                        { Title = "Movie App Microservice", Version = "v1" });
                });

            var app = builder.Build();

            app.MapGet("/", () => "Hello World! This a movie app api service build " +
            "using CQRS pattern with MediatR and clean architecture.");

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(p =>
                {
                    p.SwaggerEndpoint(url: "/swagger/v1/swagger.json", name: "Movie API v1");
                });
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(ep => ep.MapControllers());

            app.Run();
        }
    }
}