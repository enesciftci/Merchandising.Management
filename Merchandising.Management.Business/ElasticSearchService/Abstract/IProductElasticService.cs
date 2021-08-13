using Merchandising.Management.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Merchandising.Management.Business.ElasticSearchService.Abstract
{
    public interface IProductElasticService
    {
        Task Insert(ProductModel productModel);
        Task Update(ProductModel productModel);
        Task Delete(ProductModel productModel);
        Task<List<ProductModel>> FindByFilter(string query);
    }
}
