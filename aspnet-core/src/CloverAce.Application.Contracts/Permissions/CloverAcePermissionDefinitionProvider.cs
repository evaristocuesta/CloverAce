using CloverAce.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace CloverAce.Permissions;

public class CloverAcePermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(CloverAcePermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(CloverAcePermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<CloverAceResource>(name);
    }
}
