using AutoMapper;
using Merchandising.Management.Data.Entities;
using Merchandising.Management.Models;

namespace Merchandising.Management.Business.Common
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() : this("AutoMapperProfileMappings")
        {
        }

        public AutoMapperProfile(string profileName) : base(profileName)
        {
            CreateMap<Product, ProductModel>();
            CreateMap<ProductModel, Product>();
            CreateMap<Category, CategoryModel>();
            CreateMap<CategoryModel, Category>();
        }
    }
}
