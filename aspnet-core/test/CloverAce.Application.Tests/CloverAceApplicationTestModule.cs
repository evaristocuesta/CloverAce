using Volo.Abp.Modularity;

namespace CloverAce;

[DependsOn(
    typeof(CloverAceApplicationModule),
    typeof(CloverAceDomainTestModule)
    )]
public class CloverAceApplicationTestModule : AbpModule
{

}
