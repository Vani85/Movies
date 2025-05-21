using Microsoft.AspNetCore.Mvc;
using MovieBookingAPI.Models.DatabaseModels;
using MovieBookingAPI.Repositories;
namespace MovieBookingAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ShowController : ControllerBase
{
    private readonly IShowRepository _showRepository;
    public ShowController(IShowRepository showRepository)
    {
        _showRepository = showRepository;
    }

    // GET: /Movies
    [HttpGet("ByName")]
    public ActionResult<IEnumerable<Show>> GetShowsAvailableForMovieByName([FromQuery] string movieName)
    {
        var shows = _showRepository.GetRunningShowsForMovieByName(movieName);
        if (shows == null)
        {
            return NotFound();
        }
        return Ok(shows);
    }
    
        // GET: /Movies
    [HttpGet("ByDate")]
    public ActionResult<IEnumerable<Show>> GetShowsAvailableForMovieByNameAndDate([FromQuery] string movieName, string showDate)
    {
        var shows = _showRepository.GetRunningShowsForMovieByNameAndDate(movieName, DateOnly.FromDateTime(DateTime.Parse(showDate)));        
        if (shows == null)
        {
            return NotFound();
        }
        return Ok(shows);
    }
}