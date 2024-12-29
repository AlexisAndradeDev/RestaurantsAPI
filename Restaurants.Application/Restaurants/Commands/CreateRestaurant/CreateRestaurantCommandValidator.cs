using FluentValidation;
using Restaurants.Application.Restaurants.Dtos;

namespace Restaurants.Application.Restaurants.Commands.CreateRestaurant;

public class CreateRestaurantCommandValidator : AbstractValidator<CreateRestaurantCommand>
{
    private readonly List<string> validCategories = ["Italian", "Mexican", "Japanese", "French"];

    public CreateRestaurantCommandValidator()
    {
        RuleFor(dto => dto.Name)
            .Length(3, 100);

        RuleFor(dto => dto.Category)
            .Must(validCategories.Contains)
            .WithMessage("Please choose from the valid categories.");

        // Using a custom validator
        //RuleFor(dto => dto.Category)
        //    .Custom((value, context) =>
        //    {
        //        var isValidCategory = validCategories.Contains(value);
        //        if (!isValidCategory)
        //        {
        //            context.AddFailure("Category", "Please choose from the valid categories.");
        //        }
        //    });

        //// Use when nullable reference types are not enabled
        //RuleFor(dto => dto.Description)
        //    .NotEmpty().WithMessage("Description is required.");

        //// Use when nullable reference types are not enabled
        //RuleFor(dto => dto.Category)
        //    .NotEmpty().WithMessage("Category is required.");

        RuleFor(dto => dto.ContactEmail)
            .EmailAddress().WithMessage("Enter a valid email.");

        RuleFor(dto => dto.ContactNumber)
            .Matches(@"^\d{2}-\d{8}").WithMessage("Enter a valid phone number using the following format: XX-XXXXXXXX");

        RuleFor(dto => dto.PostalCode)
            .Matches(@"^\d{2}-\d{3}").WithMessage("Enter a valid postal code using the following format: XX-XXX.");
    }
}
