using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace CloverAce;

[Dependency(ReplaceServices = true)]
public class CloverAceBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "CloverAce";
}
