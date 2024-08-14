﻿using FluentValidation;
using Restaurants.Application.Restaurants.Dtos;

namespace Restaurants.Application.Restaurants.Validators;

public class CreateRestaurantDtoValidator : AbstractValidator<CreateRestaurantDto>
{
    private readonly List<string> _validCategories = ["Italian", "Mexican", "Japanese", "American", "Indian"];

    public CreateRestaurantDtoValidator()
    {
        RuleFor(dto => dto.Name)
            .Length(3, 100);
        RuleFor(dto => dto.Description)
            .NotEmpty().WithMessage("Description is required.");
        RuleFor(dto => dto.Category)
            .Must(_validCategories.Contains)
            .WithMessage("Invalid category. Please, choose from the valid categories.");

        RuleFor(dto => dto.ContentEmail)
            .EmailAddress().WithMessage("Please, provide a valid email address.");

        RuleFor(dto => dto.PostalCode)
            .Matches(@"^\d{2}-\d{3}$")
            .WithMessage("Please provide a valid post code (XX-XXX).");
    }
}