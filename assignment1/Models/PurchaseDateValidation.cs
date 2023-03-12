using System.ComponentModel.DataAnnotations;

namespace assignment1.Models;

public class PurchaseDateValidation : ValidationAttribute
{
    public override bool IsValid(object? value)
    {
        var purchaseDate = Convert.ToDateTime(value);
        return purchaseDate <= DateTime.Now;
    }
}
