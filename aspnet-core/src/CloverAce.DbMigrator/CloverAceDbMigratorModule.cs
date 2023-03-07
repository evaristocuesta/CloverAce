using CloverAce.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace CloverAce.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(CloverAceEntityFrameworkCoreModule),
    typeof(CloverAceApplicationContractsModule)
    )]
public class CloverAceDbMigratorModule : AbpModule
{

}
