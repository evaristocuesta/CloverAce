using MediatR;
using System;

namespace CloverAce.Accounts.Queries.GetAccountById;

public class GetAccountByIdCmd : IRequest<AccountDto>
{
    public Guid AccountId { get; set; }
}
