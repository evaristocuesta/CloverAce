using MediatR;
using System.Collections.Generic;

namespace CloverAce.Accounts.Queries.GetAccounts;

public class GetAccountsCmd : IRequest<IEnumerable<AccountDto>>
{
}
