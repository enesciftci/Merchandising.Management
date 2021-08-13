using Merchandising.Management.Business.ElasticSearchService;
using Merchandising.Management.Business.ElasticSearchService.Abstract;
using Merchandising.Management.Business.Service;
using Merchandising.Management.Business.Service.Abstracts;
using Microsoft.Extensions.DependencyInjection;

namespace Merchandising.Management.Api.Infrastructure.ConfigureServices
{
    public static class AppServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductElasticService, ProductElasticService>();

            //services.AddSingleton<IValidator<ProductModel>, ProductValidator>();

            return services;
        }
    }
}
