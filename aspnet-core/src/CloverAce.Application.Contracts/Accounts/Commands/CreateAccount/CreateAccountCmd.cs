using MediatR;

namespace CloverAce.Accounts.Commands.CreateAccount
{
    public class CreateAccountCmd : IRequest<CreateAccountCmdResponse>
    {
        public string Name { get; set; }
    }
}
