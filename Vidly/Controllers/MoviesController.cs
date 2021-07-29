using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;
using Vidly.ViewModels;
using Vidly.Support;
using System.Data.Entity.Validation;

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
        //=======================================//
        public ActionResult Index()
        {
            if (User.IsInRole(RoleName.CanManageMovie))
                return View("List");
            
            return View("ReadOnlyList");
        }
        public ActionResult Details(int? id)
        {
            if (id is null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var movie = _context.Movies.Include(g => g.Genre).SingleOrDefault(c => c.Id == id);
            if (movie is null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }
            return View(movie);
        }

        [Authorize(Roles = RoleName.CanManageMovie)]
        public ActionResult New()
        {
            var genres = _context.Genres.ToList();
            var viewModel = new MovieFormViewModel
            {
                Movie = new Movie() { DateAdded = DateTime.Now },
                Genres = genres
            };
            return View("MovieForm", viewModel);
        }
        [Authorize(Roles = RoleName.CanManageMovie)]
        public ActionResult Edit(int Id)
        {
            var movie = _context.Movies.FirstOrDefault(c => c.Id == Id);
            var genres = _context.Genres.ToList();
            if (movie == null)
                return HttpNotFound();
            var viewModel = new MovieFormViewModel
            {
                Movie = movie,
                Genres = genres
            };
            return View("MovieForm", viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.CanManageMovie)]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel
                {
                    Movie = movie,
                    Genres = _context.Genres.ToList()
                };
                return View("MovieForm", viewModel);
            }
            if (movie.Id == 0)
            {
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.NumberInStock = movie.NumberInStock;
                movieInDb.ReleaseDate = movie.ReleaseDate;
            }
            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                Console.WriteLine(e);
            }
            

            return RedirectToAction(ActionHelpers.Index, ActionHelpers.Movies);
        }
    }
}