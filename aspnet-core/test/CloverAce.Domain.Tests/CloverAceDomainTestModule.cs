using CloverAce.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace CloverAce;

[DependsOn(
    typeof(CloverAceEntityFrameworkCoreTestModule)
    )]
public class CloverAceDomainTestModule : AbpModule
{

}
