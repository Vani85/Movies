using Microsoft.EntityFrameworkCore;
using MovieBookingAPI.Models.DatabaseModels;

namespace MovieBookingAPI.Database;

public class MovieBookingDbContext : DbContext
{
    private readonly IConfiguration _configuration;
    public MovieBookingDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_configuration["ConnectionStrings:MovieBookingDb"]);
    }

    public DbSet<Movies> Movies { get; set; }
    public DbSet<Theatre> Theatre { get; set; }
    public DbSet<TheatreSeats> TheatreSeats { get; set; }
    public DbSet<Show> Show { get; set; }    
    public DbSet<Booking> Booking { get; set; }
}