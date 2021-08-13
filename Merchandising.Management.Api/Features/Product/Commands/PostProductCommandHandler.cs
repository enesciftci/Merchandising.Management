using AutoMapper;
using MediatR;
using Merchandising.Management.Business.ElasticSearchService.Abstract;
using Merchandising.Management.Business.Service.Abstracts;
using Merchandising.Management.Models;
using System.Threading;
using System.Threading.Tasks;

namespace Merchandising.Management.Api.Features.Product.Commands
{
    public class PostProductCommandHandler : IRequestHandler<PostProductCommand, ProductModel>
    {
        private readonly IProductService _productService;
        private readonly IProductElasticService _productElasticService;
        private readonly IMapper _mapper;
        public PostProductCommandHandler(
            IProductService productService,
            IProductElasticService productElasticService,
            IMapper mapper)
        {
            _productService = productService;
            _productElasticService = productElasticService;
            _mapper = mapper;
        }
        public async Task<ProductModel> Handle(PostProductCommand request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Data.Entities.Product>(request.productModel);
            product = await _productService.Insert(product);
            await _productElasticService.Insert(request.productModel);
            return _mapper.Map<ProductModel>(product);
        }
    }
}
