using System.ComponentModel.DataAnnotations;

namespace assignment1.Models;

internal class ReleaseDateValidation : ValidationAttribute
{
    public override bool IsValid(object? value)
    {
        var releaseDate = Convert.ToInt32(value);
        return releaseDate <= 2020;
    }
}