using Merchandising.Management.Business.ElasticSearchService.Abstract;
using Merchandising.Management.Data.Entities;
using Merchandising.Management.Models;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merchandising.Management.Business.ElasticSearchService
{
    //bilgisayarımdaki sorundan dolayı elasticsearch'ü tam olarak test edemedim.
    public class ProductElasticService : IProductElasticService
    {
        private readonly IElasticClient _elasticClient;
        public ProductElasticService(IElasticClient elasticClient)
        {
            _elasticClient = elasticClient;
        }
        public async Task Delete(ProductModel productModel)
        {
            await _elasticClient.DeleteAsync<ProductModel>(productModel);
        }

        public async Task<List<ProductModel>> FindByFilter(string query)
        {
            var searchResult = await _elasticClient
                            .SearchAsync<ProductModel>(s => s
                            .Query(q => q
                            .MultiMatch(m => m
                                .Fields(f => f
                                    .Field(p => p.Title)
                                    .Field(p => p.Description)
                                    .Field(p => p.Category.Name))
                                    .Query(query))));
            return searchResult.Documents.ToList();
        }

        public async Task Insert(ProductModel productModel)
        {
            await _elasticClient.IndexDocumentAsync(productModel);
        }

        public async Task Update(ProductModel productModel)
        {
            await _elasticClient.UpdateAsync<ProductModel>(productModel, p => p.Doc(productModel));
        }
    }
}
