using AutoMapper;
using MediatR;
using Merchandising.Management.Business.ElasticSearchService.Abstract;
using Merchandising.Management.Business.Service.Abstracts;
using Merchandising.Management.Models;
using System.Threading;
using System.Threading.Tasks;

namespace Merchandising.Management.Api.Features.Product.Commands
{
    public class DeleteProductCommandHandler : AsyncRequestHandler<DeleteProductCommand>
    {
        private readonly IProductService _productService;
        private readonly IProductElasticService _productElasticService;
        private readonly IMapper _mapper;
        public DeleteProductCommandHandler(
            IProductService productService,
            IProductElasticService productElasticService,
            IMapper mapper)
        {
            _productService = productService;
            _productElasticService = productElasticService;
            _mapper = mapper;
        }
        protected override async Task Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productService.GetById(request.id);
            if (product != null)
            {
                await _productService.Delete(product);
                await _productElasticService.Delete(_mapper.Map<ProductModel>(product));
            }
        }
    }
}
