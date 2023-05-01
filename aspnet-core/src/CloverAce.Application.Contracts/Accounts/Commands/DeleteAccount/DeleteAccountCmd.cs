using MediatR;
using System;

namespace CloverAce.Accounts.Commands.DeleteAccount;

public class DeleteAccountCmd : IRequest
{
    public Guid AccountId { get; set; }
}
