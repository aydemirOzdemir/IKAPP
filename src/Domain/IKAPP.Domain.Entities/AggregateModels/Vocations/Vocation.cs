using IKAPP.Domain.Entities.AggregateModels.Departments.DepartmentDTOs;
using IKAPP.Domain.Entities.AggregateModels.Departments;
using IKAPP.Domain.Entities.AggregateModels.Personals;
using IKAPP.Domain.Entities.AggregateModels.TypeofPermissions.TypeofPermissionDTOs;
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

    public static Vocation CreateVocation(VocationDTO vocationDTO) 
    {
        Vocation vocation = new(vocationDTO);
        vocation.UpdateBaseEntiy(null, DateTime.Now, null, Enums.Status.Added, null);
        return vocation;
    }
    public VocationDTO CreateVocationDTO() => new()
    {
        Id = this.Id,
        Name = this.Name.Value,
    };
    public static IEnumerable<VocationDTO> CreateVocationDTOs(IEnumerable<Vocation> vocations)
    {
        List<VocationDTO> vocationDTOs = new List<VocationDTO>();
        foreach (Vocation vocation in vocations)
            vocationDTOs.Add(new VocationDTO()
            {
                Id = vocation.Id,
                Name = vocation.Name.Value,
            });
        return vocationDTOs;
    }
    public Task SoftDeleteVocation()
    {
        UpdateDeleteDate(DateTime.Now);
        UpdateBaseEntiy(null, null, null, Enums.Status.Deleted, null);
        return Task.CompletedTask;
    }
    public Task UpdateVocation(VocationUpdateDTO vocationUpdateDTO)
    {
       
        UpdateBaseEntiy(new(vocationUpdateDTO.Name), null, vocationUpdateDTO.Id, Enums.Status.Modified, DateTime.Now);
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
