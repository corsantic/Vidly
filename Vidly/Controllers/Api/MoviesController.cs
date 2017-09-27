using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;
using AutoMapper;
using Vidly.Dtos;
using Vidly.Models;
using System.Data.Entity;
using Vidly.Models.DbContext;

namespace Vidly.Controllers.Api
{
    public class MoviesController: ApiController
    {

        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();

        }

        //GET /api/movies
        public IHttpActionResult GetMovies(string query=null)
        {
           var moviesQuery=_context.Movies.Include(m=>m.Genre).Where(m=>m.NumberAvailable>0);
            if (!String.IsNullOrWhiteSpace(query))
            {
                moviesQuery = moviesQuery.Where(m => m.Name.Contains(query));
                
            }
            
            var movieDtos=moviesQuery
               .ToList().Select(Mapper.Map<Movies,MovieDto>);

    
            return Ok(movieDtos);

        }

        //GET /api/movies/1

        public IHttpActionResult GetMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
                return NotFound();

            return Ok(Mapper.Map<Movies, MovieDto>(movie));


        }


        //POST /api/movies
        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();


            var movie = Mapper.Map<MovieDto, Movies>(movieDto);
            _context.Movies.Add(movie);
            _context.SaveChanges();          
            movie.Id = movieDto.Id;

            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDto);

        }
        //PUT /api/movies/1
        [HttpPut]
        public IHttpActionResult UpdateMovie(int id, MovieDto movieDto)
        {

            if (!ModelState.IsValid)
                return BadRequest();


            var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movieInDb == null)
                return NotFound();
            Mapper.Map(movieDto,movieInDb);

            _context.SaveChanges();
            return Ok();


        }
        //DELETE /api/movies/1

        [HttpDelete]
        public IHttpActionResult DeleteMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return NotFound();


            _context.Movies.Remove(movie);
            _context.SaveChanges();


            return Ok();


        }

    }
}