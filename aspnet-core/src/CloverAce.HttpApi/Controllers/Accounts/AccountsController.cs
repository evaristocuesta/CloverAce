using CloverAce.Accounts.Commands.CreateAccount;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CloverAce.Controllers.Accounts
{
    [ApiController]
    [Route("api/accounts")]
    public class AccountsController : CloverAceController
    {
        public AccountsController(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CreateAccountCmdResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status504GatewayTimeout)]
        public async Task<ActionResult<CreateAccountCmdResponse>> Post([FromBody] CreateAccountCmd cmd)
        {
            var response = await Mediator.Send(cmd);
            return Ok(response);
        }
    }
}
