using MediatR;
using Merchandising.Management.Models;

namespace Merchandising.Management.Api.Features.Product.Commands
{
    public record PostProductCommand(ProductModel productModel) : IRequest<ProductModel>;
}
