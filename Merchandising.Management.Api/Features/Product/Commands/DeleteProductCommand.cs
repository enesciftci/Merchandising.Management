using MediatR;

namespace Merchandising.Management.Api.Features.Product.Commands
{
    public record DeleteProductCommand(long id) : IRequest;
}
