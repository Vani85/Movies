using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace MovieBookingAPI.Models.DatabaseModels;

public class Theatre
{
    [Key]
    public int TheatreId { get; set; }
    public string TheatreName { get; set; }
    public int NumberOfSeats { get; set; }    
}