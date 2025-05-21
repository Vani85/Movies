using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MovieBookingAPI.Models.DatabaseModels;

public class Booking
{
    [Key]
    public int BookingId { get; set; }
    [ForeignKey("ShowId")]
    public Show show { get; set; }
    [ForeignKey("SeatId")]
    public TheatreSeats seats { get; set; }
    public string UserEmailAddress { get; set; }
    public DateOnly BookingDate { get; set; }
    
     public Booking(int showId, int seatId, string userEmailAddress, DateOnly bookingDate)
    {
        show.ShowId = showId;
        seats.SeatId = seatId;
        UserEmailAddress = userEmailAddress;
        BookingDate = bookingDate;
    }
 }