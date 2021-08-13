using Merchandising.Management.Business.Service.Abstracts;
using Merchandising.Management.Data.Context;
using Merchandising.Management.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Merchandising.Management.Business.Service
{
    public class ProductService : IProductService
    {
        private readonly MerchandisingDbContext _dbContext;
        public ProductService(MerchandisingDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task Delete(Product product)
        {
            _dbContext.Remove(product);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Product>> FindByFilter(string queryFilter)
        {
            Expression<Func<Product, bool>> predicate =
                p => p.IsAlive && (p.Description.Contains(queryFilter) ||
                p.Title.Contains(queryFilter) ||
                p.Category.Name.Contains(queryFilter));

            return await _dbContext.Products.Where(predicate).ToListAsync();
        }

        public async Task<List<Product>> FindByRange(int minRange, int maxRange)
        {
            Expression<Func<Product, bool>> predicate =
                p => p.StockQuantity >= minRange &&
                p.StockQuantity <= maxRange &&
                p.IsAlive;

            return await _dbContext.Products.Where(predicate).ToListAsync();
        }

        public async Task<Product> GetById(long id) => await _dbContext.Products.FindAsync(id);

        public async Task<Product> Insert(Product product)
        {
            var entity = (await _dbContext.Products.AddAsync(product)).Entity;
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<Product> Update(Product product)
        {
            var entity = _dbContext.Products.Update(product).Entity;
            await _dbContext.SaveChangesAsync();
            return entity;
        }
    }
}
