using System.ComponentModel.DataAnnotations;

namespace assignment1.Models;

internal class GenreValidation : ValidationAttribute
{
    public override bool IsValid(object? value)
    {
        var genre = Convert.ToString(value);
        return genre == "Action" || genre == "action" || genre == "Driving" || genre == "driving" || genre == "fps" || genre == "FPS";
    }
}