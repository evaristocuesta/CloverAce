using CloverAce.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace CloverAce.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class CloverAceController : AbpControllerBase
{
    protected CloverAceController()
    {
        LocalizationResource = typeof(CloverAceResource);
    }
}
