using LOGIC.Services.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEB_API.Models.Movie;

namespace WEB_API.Controllers
{
    [EnableCors("angular")]
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private IMovie_Service _Movie_Service;

        public MovieController(IMovie_Service Movie_Service)
        {
            _Movie_Service = Movie_Service;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> AddMovie(string name, string Director, string Language, string Price)
        {
            var result = await _Movie_Service.AddMovie(name, Director, Language, Price);
            switch (result.success)
            {
                case true:
                    return Ok(result);

                case false:
                    return StatusCode(500, result);
            }
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllMovies()
        {
            var result = await _Movie_Service.GetAllMovies();
            switch (result.success)
            {
                case true:
                    return Ok(result);

                case false:
                    return StatusCode(500, result);
            }
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> UpdateMovie(Movie_Pass_Object movie)
        {
            var result = await _Movie_Service.UpdateMovie(movie.id, movie.name, movie.Director, movie.Language, movie.Price);
            switch (result.success)
            {
                case true:
                    return Ok(result);

                case false:
                    return StatusCode(500, result);
            }
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> DeleteMovie(Movie_Pass_Object movie)
        {
            var result = await _Movie_Service.DeleteMovie(movie.id);
            switch (result.success)
            {
                case true:
                    return Ok(result);

                case false:
                    return StatusCode(500, result);
            }
        }

    }
}
