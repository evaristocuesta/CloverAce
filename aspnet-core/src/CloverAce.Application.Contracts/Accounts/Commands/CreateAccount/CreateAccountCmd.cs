using MediatR;
using System;

namespace CloverAce.Accounts.Commands.CreateAccount;

public class CreateAccountCmd : CreateOrUpdateAccountDto, IRequest<AccountDto>
{
}
