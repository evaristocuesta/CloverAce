using CloverAce.Accounts;
using CloverAce.Accounts.Commands.CreateAccount;
using CloverAce.Accounts.Commands.UpdateAccount;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CloverAce.Controllers.Accounts;

[ApiController]
[Route("api/accounts")]
public class AccountsController : CloverAceController
{
    public AccountsController(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AccountDto))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status504GatewayTimeout)]
    public async Task<ActionResult<AccountDto>> Post(
        [FromBody] CreateAccountCmd cmd,
        CancellationToken cancellationToken)
    {
        var response = await Mediator.Send(cmd, cancellationToken);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AccountDto))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status504GatewayTimeout)]
    public async Task<ActionResult<AccountDto>> Post(
        [FromBody] UpdateAccountCmd cmd,
        CancellationToken cancellationToken)
    {
        var response = await Mediator.Send(cmd, cancellationToken);
        return Ok(response);
    }
}