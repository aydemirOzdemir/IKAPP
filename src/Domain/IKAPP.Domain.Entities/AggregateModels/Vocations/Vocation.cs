using IKAPP.Domain.Entities.AggregateModels.Personals;
using IKAPP.Domain.Entities.SeedWorks;
using IKAPP.Domain.Entities.SeedWorks.Base;
using IKAPP.Domain.SeedWorks.Base.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Domain.Entities.AggregateModels.Vocations;

public  class Vocation:AuditableEntity,IAggregateRoot
{
    public Vocation(string id, Name name) : base(id, name)
    {
        Personeller = new HashSet<Personal>();
    }
    //navigation properties
    public ICollection<Personal>? Personeller { get; private set; }
}
