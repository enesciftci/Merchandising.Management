using AutoMapper;
using MediatR;
using Merchandising.Management.Business.Service.Abstracts;
using Merchandising.Management.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Merchandising.Management.Api.Features.Product.Queries
{
    public class GetProductListByRangeQueryHandler : IRequestHandler<GetProductListByRangeQuery, List<ProductModel>>
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        public GetProductListByRangeQueryHandler(
            IProductService productService,
            IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }
        public async Task<List<ProductModel>> Handle(GetProductListByRangeQuery request, CancellationToken cancellationToken)
        {
            var productList = await _productService.FindByRange(request.minRange, request.maxRange);
            return _mapper.Map<List<ProductModel>>(productList);
        }
    }
}
