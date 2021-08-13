using Merchandising.Management.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Merchandising.Management.Api.Infrastructure.ConfigureServices
{
    public static class Database
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MerchandisingDbContext>(opts =>
           opts.UseSqlServer(configuration.GetSection("ConnectionStrings").GetSection("DefaultConnection").Value));
            return services;
        }
    }
}
