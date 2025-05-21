using Microsoft.AspNetCore.Mvc;
using MovieBookingAPI.Repositories;
namespace MovieBookingAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class TheatreController : ControllerBase
{
    private readonly ITheatreRepository _theatreRepository;
    public TheatreController(ITheatreRepository theatreRepository)
    {
        _theatreRepository = theatreRepository;
    }

    // GET: 
    [HttpGet("")]
    public ActionResult<int> GetTotalNumberOfSeatsInTheatreById(int theatreId)
    {
        int seatsCount = _theatreRepository.GetNumberOfSeatsById(theatreId);
        return Ok(seatsCount);
    }
}