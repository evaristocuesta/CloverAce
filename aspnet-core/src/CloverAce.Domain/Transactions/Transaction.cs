using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace CloverAce.Entries;

public class Transaction : AuditedAggregateRoot<Guid>
{
    public DateTime Date { get; private set; }
    public string Description { get; private set; }
    public decimal Amount { get; private set; }
    public Guid AccountId { get; private set; }
}
