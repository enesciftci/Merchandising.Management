using FluentValidation;
using Merchandising.Management.Models;

namespace Merchandising.Managament.Service.Validator.ProductValidator
{
    public class ProductValidator:AbstractValidator<ProductModel>
    {
        public ProductValidator()
        {
            RuleFor(product => product.Title).NotNull().NotEmpty().WithMessage("Title cannot be null or empty");
            RuleFor(product => product.Title).MaximumLength(200).WithMessage("Title can be max 200 character");
        }
    }
}
