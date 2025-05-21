using Microsoft.EntityFrameworkCore;
using MovieBookingAPI.Database;
using MovieBookingAPI.Models.DatabaseModels;
namespace MovieBookingAPI.Repositories;

public interface IShowRepository
{
    IEnumerable<Show> GetRunningShowsForMovieByName(string movieName);  
    IEnumerable<Show> GetRunningShowsForMovieByNameAndDate(string movieName, DateOnly showDate);   
}

public class ShowRepository : IShowRepository
{
    private readonly MovieBookingDbContext _context;
    public ShowRepository(MovieBookingDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Show> GetRunningShowsForMovieByName(string movieName)
    {
        return _context.Show
               .Where(show => show.movies.MovieName.Equals(movieName))
               .Include(show => show.movies)
               .Include(show => show.theatre)
               .Include(show => show.theatre);
    }
    
    public IEnumerable<Show> GetRunningShowsForMovieByNameAndDate(string movieName, DateOnly showDate)
    {
        return _context.Show
               .Where(show => show.movies.MovieName.Equals(movieName))
               .Where(show => show.ShowDate == showDate)
               .Include(show => show.movies)
               .Include(show => show.theatre)
               .Include(show => show.theatre);            
    }
}