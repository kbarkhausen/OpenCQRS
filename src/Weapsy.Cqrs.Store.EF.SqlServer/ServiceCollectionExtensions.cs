﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Weapsy.Cqrs.Store.EF.Extensions;

namespace Weapsy.Cqrs.Store.EF.SqlServer
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddOpenCqrsSqlServerProvider(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddOpenCqrsEF(configuration);

            var connectionString = configuration.GetSection(Constants.DomainDbConfigurationConnectionString).Value;

            services.AddDbContext<DomainDbContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddTransient<IDatabaseProvider, SqlServerDatabaseProvider>();

            return services;
        }
    }
}