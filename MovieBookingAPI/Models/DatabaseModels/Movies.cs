using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace MovieBookingAPI.Models.DatabaseModels;

public class Movies
{
    [Key]
    public int MovieId { get; set; }
    public required string MovieName { get; set; }
    public required string Description { get; set; }
    public required string MovieImageUrl { get; set; }
    public required string Language { get; set; }
    public required string Cast { get; set; }
    public required string Director { get; set; }
    public required DateOnly ReleaseDate { get; set; }

    public required int DurationInMins { get; set; }
    public required bool isNowShowing { get; set; }
    
}