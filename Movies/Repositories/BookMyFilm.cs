using Microsoft.EntityFrameworkCore;
using Movies.DTO;
using Movies.Models;
using Movies.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Movies.Repositories
{
    public class BookMyFilm : IBookMyFilm
    {
        private readonly ApplicationDBContext _db;
        public BookMyFilm(ApplicationDBContext db)
        {
            this._db = db;
                
        }
        public List<Languages> AllLanguages()
        {
            Console.WriteLine("Hello World");
            return _db.LanguagesTable.ToList();
        }

        List<ReviewsDTO> ReviewList = new List<ReviewsDTO>();
        public List<ReviewsDTO> ViewReviews(int MovieId)
        {
            List<Reviews> Review1= _db.ReviewsTable.Include("Movies").Where(a => a.MoviesId == MovieId).ToList();

            foreach(Reviews review in Review1)
            {
                ReviewList.Add(new ReviewsDTO
                {
                    MovieId = MovieId,
                    MovieName = review.Movies.MoviesName,
                    Reviews = review.HonestReviews
                });
            }
            return ReviewList;
        }
       


        List<MovieDTO> MoviesName2 = new List<MovieDTO>();
        public List<MovieDTO> MoviesByLanguage(int languageId)
        {

            List<Movie> MoviesName = _db.MoviesTable.Include("Language").Where(a => a.LanguageId == languageId).ToList();
            ;

            foreach (Movie movie in MoviesName)
            {
                MoviesName2.Add(new MovieDTO
                {
                    MovieName = movie.MoviesName,
                    LanguageId = languageId,
                    LanguageName = movie.Language.LanguageNames
                }) ;
            }
            return MoviesName2;

        }

        public bool AddReviews(AddReviewRequest request)
        {
            if(request!=null)
            {
                Reviews review = new Reviews();
                review.HonestReviews = request.Reviews;
                review.MoviesId = request.MoviesId;
                _db.ReviewsTable.Add(review);
                _db.SaveChanges();
                return true;
            }
            return false;
        }

        public bool AddLanguage(AddLanguageRequest request)
        {
            if(request!=null)
            {
                Languages language = new Languages();
                language.LanguageNames = request.LanguageName;
                _db.LanguagesTable.Add(language);
                _db.SaveChanges();
                return true;
            }
            return false;
        }

        public bool AddMovies(AddMoviesRequest request)
        {
            if (request != null)
            {
                Movie films= new Movie();
                films.MoviesName = request.MoviesName;
                films.LanguageId = request.LanguageID;

                _db.MoviesTable.Add(films);
                _db.SaveChanges();
                return true;
            }
            return false;
        }

        public bool UpdateMovies(UpdateMoviesRequest request)
        {
            if (request != null)
            {
                Movie movie = _db.MoviesTable.Where(a => a.Id == request.MovieId).FirstOrDefault();
                if (movie != null)
                {

                    movie.MoviesName = string.IsNullOrEmpty(request.MoviesName) ? movie.MoviesName : request.MoviesName;
                    if(request.LanguageID>0)
                    {
                        movie.LanguageId = request.LanguageID;
                    }
                    else
                    {
                        movie.LanguageId = movie.LanguageId;
                    }
                    _db.SaveChanges();

                    return true;
                }
                return false;
            }
            return false;
        }
    }
}
