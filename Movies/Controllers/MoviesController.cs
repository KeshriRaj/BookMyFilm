using Microsoft.AspNetCore.Mvc;
using Movies.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;


namespace Movies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IBookMyFilm repository;

        public MoviesController(IBookMyFilm repository)
        {
            this.repository = repository;
        }

        [HttpGet("Languages")]
        public IActionResult Languages()
        {
            Console.WriteLine("Router");
            return Ok(repository.AllLanguages());
        }


        [HttpPost("AddLanguage")]

        public IActionResult AddLanguage(Request.AddLanguageRequest data)
        {
            return Ok(repository.AddLanguage(data));
        }


        [HttpGet("Films/{languageId}")]

        public IActionResult GetMovies(int languageId)
        {
            return Ok(repository.MoviesByLanguage(languageId));
        }

        [HttpPost("AddMovies")]

        public IActionResult AddMovies(Request.AddMoviesRequest data)
        {
            return Ok(repository.AddMovies(data));
        }

        [HttpGet("Reviews/{MovieId}")]

        public IActionResult Reviews(int MovieId)
        {
            return Ok(repository.ViewReviews(MovieId));
        }

        [HttpPost("AddReviews")]

        public IActionResult AddReviews(Request.AddReviewRequest data)
        {
            return Ok(repository.AddReviews(data));
        }


        [HttpPut("UpdateMovies")]

        public IActionResult UpdateMovies(Request.UpdateMoviesRequest data)
        {
            return Ok(repository.UpdateMovies(data));
        }
       


       

    }
}
