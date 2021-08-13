using AutoMapper;
using MediatR;
using Merchandising.Management.Business.ElasticSearchService.Abstract;
using Merchandising.Management.Business.Service.Abstracts;
using Merchandising.Management.Models;
using System.Threading;
using System.Threading.Tasks;

namespace Merchandising.Management.Api.Features.Product.Commands
{
    public class PutProductCommandHandler : IRequestHandler<PutProductCommand, ProductModel>
    {
        private readonly IProductService _productService;
        private readonly IProductElasticService _productElasticService;
        private readonly IMapper _mapper;
        public PutProductCommandHandler(
            IProductService productService,
            IProductElasticService productElasticService,
            IMapper mapper)
        {
            _productService = productService;
            _productElasticService = productElasticService;
            _mapper = mapper;
        }
        public async Task<ProductModel> Handle(PutProductCommand request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Data.Entities.Product>(request.productModel);
            product = await _productService.Update(product);
            await _productElasticService.Update(request.productModel);
            return _mapper.Map<ProductModel>(product);
        }
    }
}
