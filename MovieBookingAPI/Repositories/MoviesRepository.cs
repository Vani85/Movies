using MovieBookingAPI.Database;
using MovieBookingAPI.Models.DatabaseModels;
namespace MovieBookingAPI.Repositories;

public interface IMoviesRepository
{
    IEnumerable<Movies> GetNowShowingMovies();   
}

public class MoviesRepository : IMoviesRepository
{
    private readonly MovieBookingDbContext _context;
    public MoviesRepository(MovieBookingDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Movies> GetNowShowingMovies()
    {
        return _context.Movies.Where(movie => movie.IsNowShowing == true);            
    }
}