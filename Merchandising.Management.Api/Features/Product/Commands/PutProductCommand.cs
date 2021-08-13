using MediatR;
using Merchandising.Management.Models;

namespace Merchandising.Management.Api.Features.Product.Commands
{
    public record PutProductCommand(ProductModel productModel) : IRequest<ProductModel>;
}
