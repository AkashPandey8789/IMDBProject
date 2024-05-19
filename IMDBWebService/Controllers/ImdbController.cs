using IMDBWebService.Data;
using IMDBWebService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IMDBWebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImdbController : ControllerBase
    {
        IMDBDBContext context;
        public ImdbController(IMDBDBContext context)
        {
            this.context = context;

        }
        [HttpPost("addMovie")]
        public IActionResult AddMovies(MovieDTO movie)
        {
            if (ModelState.IsValid)
            {
                Movies m = new Movies
                {
                    Title=movie.Title,
                    MaleLead=movie.MaleLead,
                    FemaleLead=movie.FemaleLead,
                    Rating= movie.Rating,
                    Budget=movie.Budget,
                };
                foreach(ActorDTO actor in movie.Actors)
                {
                    m.Actors.Add(new Actor
                    {
                        FirstName=actor.FirstName,
                        LastName=actor.LastName,
                        MiddleName=actor.MiddleName,
                        Age=  actor.Age
                    });
                }
                context.Movies.Add(m);
                context.SaveChanges();
                return Ok(m);
            }
            return BadRequest("Invalid model state");
        }

        [HttpGet("getMovies")]
        public IActionResult ViewMovies()
        {
            return Ok(context.Movies.ToList());
        }

    }
}
