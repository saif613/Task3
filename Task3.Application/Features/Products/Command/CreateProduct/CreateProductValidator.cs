using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Task3.Application.Features.Products.Command.CreateProduct
{
    public class CreateProductValidator
     : AbstractValidator<CreateProductCommand>
    {
        public CreateProductValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Product name is required.")
                .MinimumLength(2)
                .WithMessage("Product name must be at least 2 characters.")
                .MaximumLength(100)
                .WithMessage("Product name cannot exceed 100 characters.");

            RuleFor(x => x.Price)
                .GreaterThan(0)
                .WithMessage("Product price must be greater than zero.");
        }
    }
}
