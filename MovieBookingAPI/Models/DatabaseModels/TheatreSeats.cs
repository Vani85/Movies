using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MovieBookingAPI.Models.DatabaseModels;

public class TheatreSeats
{
    [Key]
    public int SeatId { get; set; }
    [ForeignKey("TheatreId")]
    public Theatre theatre { get; set; }
    public string Row { get; set; }
    public int Column { get; set; }
    public string SeatName { get; set; }
    public int CostInPounds { get; set; }
}