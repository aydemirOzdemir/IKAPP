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

    public static Vocation CreateVocation(VocationDTO vocationDTO) => new(vocationDTO) { CreatedDate = DateTime.Now ,Status=Enums.Status.Added};
    public VocationDTO CreateVocationDTO() => new()
    {
        Id = this.Id,
        Name = this.Name.Value,
    };
    public Task SoftDeleteVocation()
    {
        IsActive = false;
        DeletedDate = DateTime.Now;
        Status = Enums.Status.Deleted;
        return Task.CompletedTask;
    }
    public Task UpdateVocation(VocationUpdateDTO vocationUpdateDTO)
    {
        Id=vocationUpdateDTO.Id;
        Name = new(vocationUpdateDTO.Name);
        ModifiedDate = DateTime.Now;
        Status = Enums.Status.Modified;
        return Task.CompletedTask;
    }
    public Task AddPersonals(List<Personal> personals)
    {
        foreach (Personal personal in personals)
        {
            Personeller.Add(personal);
        }

        return Task.CompletedTask;
    }
}
