using FluentValidation;

namespace Products.Application.Product.Commands.Update
{
    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidator()
        {
            RuleFor(p => p.Title).NotEmpty().WithMessage("{Title} cannot be empty").NotNull().MaximumLength(200).WithMessage("{Title cannot be more than 200 characters}");
            RuleFor(p => p.Description).NotEmpty().WithMessage("{Title} cannot be empty").NotNull().MaximumLength(5000).WithMessage("{Title cannot be more than 5000 characters}");
            RuleFor(p => p.CategoryId).NotEmpty().WithMessage("{CategoryId} is Required")
                .NotEqual(0).WithMessage("{Category} must not be zero");

            RuleFor(p => p.Price)
                .NotNull().WithMessage("{Price} is Required")
                .GreaterThanOrEqualTo(0).WithMessage("{Price} must not be less than zero");
        }
    }
}