using System;
using System.Collections.Generic;
using System.Text;
using CloverAce.Localization;
using Volo.Abp.Application.Services;

namespace CloverAce;

/* Inherit your application services from this class.
 */
public abstract class CloverAceAppService : ApplicationService
{
    protected CloverAceAppService()
    {
        LocalizationResource = typeof(CloverAceResource);
    }
}
