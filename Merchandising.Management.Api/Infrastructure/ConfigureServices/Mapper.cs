using AutoMapper;
using Merchandising.Management.Business.Common;
using Microsoft.Extensions.DependencyInjection;

namespace Merchandising.Management.Api.Infrastructure.ConfigureServices
{
    public static class Mapper
    {
        public static IServiceCollection AddAutoMapper(this IServiceCollection services)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfile());
            });

            var mapper = config.CreateMapper();
            services.AddSingleton(mapper);
            return services;
        }
    }
}
