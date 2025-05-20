using System.Security;
using System.Security.Claims;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using MovieBookingAPI.Models.DatabaseModels;
using MovieBookingAPI.Repositories;
namespace MovieBookingAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class MoviesController : ControllerBase
{
    private readonly IMoviesRepository _moviesRepository;
    public MoviesController(IMoviesRepository moviesRepository)
    {
        _moviesRepository = moviesRepository;
    }

    // GET: /Movies
    [HttpGet("")]
    public ActionResult<IEnumerable<Movies>> GetNowShowingMovies()
    {
        var movies = _moviesRepository.GetNowShowingMovies();        
        if (movies == null)
        {
            return NotFound();
        }
        return Ok(movies);
    }
}