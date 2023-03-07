using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using CloverAce.Data;
using Volo.Abp.DependencyInjection;

namespace CloverAce.EntityFrameworkCore;

public class EntityFrameworkCoreCloverAceDbSchemaMigrator
    : ICloverAceDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreCloverAceDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the CloverAceDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<CloverAceDbContext>()
            .Database
            .MigrateAsync();
    }
}
