using JetBrains.Annotations;
using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace CloverAce.Accounts;

public class Account : FullAuditedAggregateRoot<Guid>
{
    public string Name { get; internal set; }

    private Account() 
    { 
    
    }

    internal Account(Guid id, [NotNull] string name) : base(id) 
    {
        Name = name;
    }
}
