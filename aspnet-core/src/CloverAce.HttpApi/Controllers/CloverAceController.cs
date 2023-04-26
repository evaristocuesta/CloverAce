using CloverAce.Localization;
using MediatR;
using Volo.Abp.AspNetCore.Mvc;

namespace CloverAce.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class CloverAceController : AbpControllerBase
{
    protected readonly IMediator Mediator;

    protected CloverAceController(IMediator mediator)
    {
        Mediator = mediator;
        LocalizationResource = typeof(CloverAceResource);
    }
}
