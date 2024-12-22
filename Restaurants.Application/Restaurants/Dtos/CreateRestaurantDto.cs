using System.ComponentModel.DataAnnotations;

namespace Restaurants.Application.Restaurants.Dtos;

public class CreateRestaurantDto
{
    [StringLength(100, MinimumLength = 3, ErrorMessage = "String must be between 3 and 100 characters long.")]
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public string Category { get; set; } = default!;
    public bool HasDelivery { get; set; }
    [EmailAddress(ErrorMessage = "Enter a valid email.")]
    public string? ContactEmail { get; set; }
    [RegularExpression(@"^\d{2}-\d{8}", ErrorMessage = "Enter a valid phone number using the following format: XX-XXXXXXXX")]
    public string? ContactNumber { get; set; }

    public string? City { get; set; }
    public string? Street { get; set; }
    [RegularExpression(@"^\d{2}-\d{3}", ErrorMessage = "Enter a valid postal code using the following format: XX-XXX.")]
    public string? PostalCode { get; set; }
}
