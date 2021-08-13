using Merchandising.Management.Business.ElasticSearchService;
using Merchandising.Management.Data.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nest;
using System;

namespace Merchandising.Management.Api.Infrastructure.ConfigureServices
{
    public static class ElasticSearch
    {
        public static IServiceCollection AddElasticSearch(this IServiceCollection services, IConfiguration configuration)
        {
            var url = configuration.GetSection("ElasticSearch").GetSection("URL").Value;

            var settings = new ConnectionSettings(new Uri(url))
                .DefaultIndex(IndexConstants.Products);

            var client = new ElasticClient(settings);

            services.AddSingleton<IElasticClient>(client);

            CreateIndex(client, IndexConstants.Products);
            return services;
        }

        private static void CreateIndex(IElasticClient client, string indexName)
        {
            var createIndexResponse = client.Indices.Create(indexName,
                index => index.Map<Product>(x => x.AutoMap())
            );
        }
    }
}
