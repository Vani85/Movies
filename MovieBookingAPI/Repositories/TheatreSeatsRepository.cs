using MovieBookingAPI.Database;
using MovieBookingAPI.Models.DatabaseModels;
namespace MovieBookingAPI.Repositories;

public interface ITheatreSeatsRepository
{
    IEnumerable<TheatreSeats> GetSeatsByTheatreId(int TheatreId);   
    IEnumerable<TheatreSeats> GetSeatsByTheatreName(string TheatreName);     
}

public class TheatreSeatsRepository : ITheatreSeatsRepository
{
    private readonly MovieBookingDbContext _context;
    public TheatreSeatsRepository(MovieBookingDbContext context)
    {
        _context = context;
    }

    public IEnumerable<TheatreSeats> GetSeatsByTheatreId(int TheatreId)
    {
        return _context.TheatreSeats.Where(theatre => theatre.theatre.TheatreId == TheatreId).ToList();
    }
    
    
    public IEnumerable<TheatreSeats> GetSeatsByTheatreName(string TheatreName)
    {
        return _context.TheatreSeats.Where(theatreSeats => theatreSeats.theatre.TheatreName.Equals(TheatreName)).ToList();        
    }
}