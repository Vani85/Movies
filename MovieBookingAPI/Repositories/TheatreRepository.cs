using MovieBookingAPI.Database;
namespace MovieBookingAPI.Repositories;

public interface ITheatreRepository
{
    int GetNumberOfSeatsById(int TheatreId);   
    int GetNumberOfSeatsByName(string TheatreName);   
}

public class TheatreRepository : ITheatreRepository
{
    private readonly MovieBookingDbContext _context;
    public TheatreRepository(MovieBookingDbContext context)
    {
        _context = context;
    }

    public int GetNumberOfSeatsById(int TheatreId)
    {
        var theatre = _context.Theatre.Where(theatre => theatre.TheatreId == TheatreId).FirstOrDefault();
        if (theatre == null)
            throw new Exception("Theatre not found.");
        return theatre.NumberOfSeats; 
    }

    public int GetNumberOfSeatsByName(string TheatreName)
    {
        var theatre = _context.Theatre.Where(theatre => theatre.TheatreName.Equals(TheatreName)).FirstOrDefault();
        if (theatre == null)
            throw new Exception("Theatre not found.");
        return theatre.NumberOfSeats;        
    }
}