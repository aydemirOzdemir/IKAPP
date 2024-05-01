using IKAPP.Domain.Entities.AggregateModels.Advances;
using IKAPP.Domain.Entities.AggregateModels.Companies;
using IKAPP.Domain.Entities.AggregateModels.Departments.DepartmentDTOs;
using IKAPP.Domain.Entities.AggregateModels.Personals;
using IKAPP.Domain.Entities.SeedWorks;
using IKAPP.Domain.Entities.SeedWorks.Base;
using IKAPP.Domain.SeedWorks.Base.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Domain.Entities.AggregateModels.Departments;

public class Department : AuditableEntity, IAggregateRoot
{
    private Department(DepartmentDTO departmentDTO) : base(departmentDTO.Id, new(departmentDTO.Name))
    {
        Personeller = new HashSet<Personal>();
        Siketler = new HashSet<DepartmentCompany>();
    }
    //navigation properties
    public ICollection<Personal>? Personeller { get; private set; }
    public ICollection<DepartmentCompany>? Sirketler { get; private set; }

    public static Department CreateDepartment(DepartmentDTO departmentDTO) => new(departmentDTO) { CreatedDate = DateTime.Now, Status=Enums.Status.Added };

    public DepartmentDTO CreateDepartmentDTO() => new()
    {
        Id = this.Id,
        Name = this.Name.Value,
    };
    public Task SoftDeleteDepartment()
    {
        IsActive = false;
        DeletedDate = DateTime.Now;
        Status= Enums.Status.Deleted;
        return Task.CompletedTask;
    }
    public Task UpdateDepartment(DepartmentUpdateDTO departmentUpdateDTO)
    {
        Id = departmentUpdateDTO.Id;
        Name=new(departmentUpdateDTO.Name);
        ModifiedDate = DateTime.Now;
        Status=Enums.Status.Modified;
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
    public Task AddCompanies(List<DepartmentCompany> companies)
    {
        foreach (DepartmentCompany company in companies)
        {
            Siketler.Add(company);
        }

        return Task.CompletedTask;
    }

}
