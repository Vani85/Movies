using MovieBookingAPI.Database;
using MovieBookingAPI.Models.DatabaseModels;
namespace MovieBookingAPI.Repositories;

public interface IBookingRepository
{
    void BookSeat(int ShowId, int SeatId, string userEmailAddress);   
}

public class BookingRepository : IBookingRepository
{
    private readonly MovieBookingDbContext _context;
    public BookingRepository(MovieBookingDbContext context)
    {
        _context = context;
    }

    public void BookSeat(int ShowId, int SeatId, string userEmailAddress)
    {
        _context.Booking.Add(new Booking(ShowId, SeatId, userEmailAddress, new DateOnly()));
        _context.SaveChanges();
    }
}