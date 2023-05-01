using CloverAce.Accounts;
using CloverAce.Accounts.Commands.CreateAccount;
using CloverAce.Accounts.Commands.DeleteAccount;
using CloverAce.Accounts.Commands.UpdateAccount;
using CloverAce.Accounts.Queries.GetAccountById;
using CloverAce.Accounts.Queries.GetAccounts;
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

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AccountDto))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status504GatewayTimeout)]
    public async Task<ActionResult<AccountDto>> Get(CancellationToken cancellationToken)
    {
        var response = await Mediator.Send(
            new GetAccountsCmd(), 
            cancellationToken);

        return Ok(response);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AccountDto))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status504GatewayTimeout)]
    public async Task<ActionResult<AccountDto>> Get(
        [FromRoute] Guid id,
        CancellationToken cancellationToken)
    {
        var response = await Mediator.Send(
            new GetAccountByIdCmd { AccountId = id }, 
            cancellationToken);
        
        return Ok(response);
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
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status504GatewayTimeout)]
    public async Task<ActionResult<AccountDto>> Put(
        [FromBody] UpdateAccountCmd cmd,
        CancellationToken cancellationToken)
    {
        var response = await Mediator.Send(cmd, cancellationToken);
        return Ok(response);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status504GatewayTimeout)]
    public async Task<IActionResult> Delete(
        [FromRoute] Guid id,
        CancellationToken cancellationToken)
    {
        var cmd = new DeleteAccountCmd { AccountId =  id };
        await Mediator.Send(cmd, cancellationToken);
        return Ok();
    }
}