﻿

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ordering.Infrastructure
{
    public static class DepedencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            /*services.AddDbContext<OrderContext>(options => options.UseSqlServer(configuration.GetConnectionString("OrderConnection"),
                                                                b => b.MigrationsAssembly(typeof(OrderContext).Assembly.FullName)));*/

            return services;
        }
    }
}