using Merchandising.Management.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Merchandising.Management.Business.Service.Abstracts
{
    public interface IProductService
    {
        Task<Product> GetById(long id);
        Task<Product> Insert(Product product);
        Task Delete(Product product);
        Task<Product> Update(Product product);
        Task<List<Product>> FindByFilter(string queryFilter);
        Task<List<Product>> FindByRange(int minRange, int maxRange);
    }
}
