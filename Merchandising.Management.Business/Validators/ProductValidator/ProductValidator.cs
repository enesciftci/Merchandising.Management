using FluentValidation;
using Merchandising.Management.Models;

namespace Merchandising.Management.Business.Validators.ProductValidator
{
    public class ProductValidator : AbstractValidator<ProductModel>
    {
        public ProductValidator()
        {
            RuleFor(product => product.Title).NotNull().NotEmpty().WithMessage("Title cannot be null or empty");
            RuleFor(product => product.Title).MaximumLength(200).WithMessage("Title can be max 200 character");
            RuleFor(product => product.StockQuantity).GreaterThanOrEqualTo(product => product.Category.MinStockQuantity).WithMessage(product => $"Product should have a minimum {product.Category.MinStockQuantity} stock quantity");
            RuleFor(product => product.Category).NotNull().WithMessage("Product must have a category to be live.");
        }
    }
}
