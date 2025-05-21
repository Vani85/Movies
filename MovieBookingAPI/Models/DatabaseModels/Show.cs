using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MovieBookingAPI.Models.DatabaseModels;

public class Show
{
    [Key]
    public int ShowId { get; set; }
    [ForeignKey("MovieId")]
    public Movies movies { get; set; }
    [ForeignKey("TheatreId")]
    public Theatre theatre { get; set; }
    public DateOnly ShowDate { get; set; }
    public string ShowTime { get; set; }  
}