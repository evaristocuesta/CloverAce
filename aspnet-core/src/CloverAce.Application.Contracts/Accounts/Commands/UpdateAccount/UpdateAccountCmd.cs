using MediatR;
using System;

namespace CloverAce.Accounts.Commands.UpdateAccount;

public class UpdateAccountCmd : CreateOrUpdateAccountDto, IRequest<UpdateAccountCmdResponse>
{
    public Guid AccountId { get; set; }
}
