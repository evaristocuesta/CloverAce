using CloverAce.Localization;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using Volo.Abp.AspNetCore.Mvc;

namespace CloverAce.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class CloverAceController : AbpControllerBase
{
    protected CloverAceController(IServiceProvider serviceProvider)
    {
        ServiceProvider = serviceProvider;
        Mediator = serviceProvider.GetService<IMediator>();
        LocalizationResource = typeof(CloverAceResource);
    }

    protected IServiceProvider ServiceProvider { get; }
    protected IMediator Mediator { get; }
}
