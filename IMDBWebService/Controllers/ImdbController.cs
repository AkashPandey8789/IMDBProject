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
                m.MovieActors = new List<MovieActor>();
                
                foreach (ActorDTO a in movie.Actors) 
                {
                    m.MovieActors.Add(new MovieActor
                    {
                        Actor = new Actor
                        {
                            FirstName=a.FirstName,
                            LastName=a.LastName,
                            MiddleName = a.MiddleName,
                            Age=a.Age,
                        }
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
