using System.ComponentModel.DataAnnotations;

namespace assignment1.Models;

public class Game
{
    [Key]
    public int GameId { get; set; }

    [Required]
    public string Title { get; set; } = "";

    [Required]
    public string Developer { get; set; } = "";



    [Required]
    [GenreValidation(ErrorMessage = "Please select between Action, Driving and FPS")]
    public string Genre { get; set; } = "";

    [Required]
    [Display(Name = "Release Year")]
    [ReleaseDateValidation(ErrorMessage = "Must be released in 2020 or earlier")]
    public int ReleaseYear { get; set; }

    [DataType(DataType.Date)]
    [Display(Name = "Purchase Date")]
    [PurchaseDateValidation(ErrorMessage = "Date can't be in the future.")]
    public DateTime? PurchaseDate { get; set; }

    [Range(1,100)]
    public int? Rating { get; set; }

}