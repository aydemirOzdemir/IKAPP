using IKAPP.Domain.Entities.AggregateModels.Personals;
using IKAPP.Domain.Entities.AggregateModels.Vocations.VocationDTOs;
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
    public Vocation(VocationDTO vocationDTO) : base(vocationDTO.Id,new( vocationDTO.Name))
    {
        Personeller = new HashSet<Personal>();
    }
    //navigation properties
    public ICollection<Personal>? Personeller { get; private set; }

    public static Vocation CreateVocation(VocationDTO vocationDTO) => new(vocationDTO) { CreatedDate = DateTime.Now };
    public VocationDTO CreateVocationDTO() => new()
    {
        Id = this.Id,
        Name = this.Name.Value,
    };
}
