using MediatR;
using System;

namespace CloverAce.Accounts.Commands.UpdateAccount;

public class UpdateAccountCmd : CreateOrUpdateAccountDto, IRequest<AccountDto>
{
    public Guid AccountId { get; set; }
}
