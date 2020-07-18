using Movies.DTO;
using Movies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Repositories
{
    public interface IBookMyFilm
    {
        public List<Languages> AllLanguages();

        public List<ReviewsDTO> ViewReviews(int MovieId);

        public List<MovieDTO> MoviesByLanguage(int languageId);

        public bool AddReviews(Request.AddReviewRequest request);

        public bool AddLanguage(Request.AddLanguageRequest data);

        public bool AddMovies(Request.AddMoviesRequest data);

        public bool UpdateMovies(Request.UpdateMoviesRequest data);

    }
}
