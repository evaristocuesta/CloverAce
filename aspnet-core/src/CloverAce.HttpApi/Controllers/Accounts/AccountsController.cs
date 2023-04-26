using CloverAce.Accounts.Commands.CreateAccount;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CloverAce.Controllers.Accounts
{
    [ApiController]
    [Route("api/accounts")]
    public class AccountsController : CloverAceController
    {
        public AccountsController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CreateAccountCmdResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CreateAccountCmdResponse>> Post([FromBody] CreateAccountCmd cmd)
        {
            var response = await Mediator.Send(cmd);
            return Ok(response);
        }
    }
}
