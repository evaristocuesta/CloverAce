using Volo.Abp.Settings;

namespace CloverAce.Settings;

public class CloverAceSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(CloverAceSettings.MySetting1));
    }
}
