using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace CloverAce.Data;

/* This is used if database provider does't define
 * ICloverAceDbSchemaMigrator implementation.
 */
public class NullCloverAceDbSchemaMigrator : ICloverAceDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
