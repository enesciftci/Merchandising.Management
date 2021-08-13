using MediatR;
using Merchandising.Management.Models;
using System.Collections.Generic;

namespace Merchandising.Management.Api.Features.Product.Queries
{
    public record GetProductListByFilterQuery(string queryFilter) : IRequest<List<ProductModel>>;
}
