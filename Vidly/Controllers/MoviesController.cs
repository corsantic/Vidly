using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Vidly.Migrations;
using Vidly.Models;
using Vidly.Models.DbContext;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ViewResult Index()
        {
            if (User.IsInRole(RoleName.CanManageMovies))
                return View("List");
          
         
                return View("ReadOnlyList");
          
            
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ViewResult New()
        {
            var genres = _context.Genres.ToList();

            var viewModel = new MovieFormViewModel
            {
                Genres = genres 
            };

            return View("MovieForm", viewModel);
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (movie == null)
                return HttpNotFound();

            var viewModel = new MovieFormViewModel(movie)
            {
                       
                Genres = _context.Genres.ToList()
            };

            return View("MovieForm", viewModel);
        }


        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return HttpNotFound();

            return View(movie);

        }


        // GET: Movies/Random
    

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Save(Movies movies)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel(movies)
                {
                    Genres = _context.Genres.ToList()
                };
                return View("MovieForm", viewModel);
            }
            if (movies.Id == 0)
            {
                movies.DateAdded = DateTime.Now;
                _context.Movies.Add(movies);
            }
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movies.Id);
                movieInDb.Name = movies.Name;
                movieInDb.GenreId = movies.GenreId;
                movieInDb.NumberInStock = movies.NumberInStock;
                movieInDb.ReleaseDate = movies.ReleaseDate;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }
    }
}