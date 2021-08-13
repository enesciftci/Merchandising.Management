using AutoMapper;
using MediatR;
using Merchandising.Management.Business.ElasticSearchService.Abstract;
using Merchandising.Management.Business.Service.Abstracts;
using Merchandising.Management.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Merchandising.Management.Api.Features.Product.Queries
{
    public class GetProductListByFilterQueryHandler : IRequestHandler<GetProductListByFilterQuery, List<ProductModel>>
    {
        private readonly IProductService _productService;
        private readonly IProductElasticService _productElasticService;
        private readonly IMapper _mapper;
        public GetProductListByFilterQueryHandler(
            IProductService productService,
            IProductElasticService productElasticService,
            IMapper mapper)
        {
            _productService = productService;
            _productElasticService = productElasticService;
            _mapper = mapper;
        }
        public async Task<List<ProductModel>> Handle(GetProductListByFilterQuery request, CancellationToken cancellationToken)
        {
            //var productList = await _productElasticService.FindByFilter(request.queryFilter);
            var productList = await _productService.FindByFilter(request.queryFilter);
            return _mapper.Map<List<ProductModel>>(productList);
        }
    }
}
