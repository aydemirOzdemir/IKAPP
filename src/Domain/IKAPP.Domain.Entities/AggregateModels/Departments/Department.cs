using IKAPP.Domain.Entities.AggregateModels.Advances;
using IKAPP.Domain.Entities.AggregateModels.Companies;
using IKAPP.Domain.Entities.AggregateModels.Companies.CompanyDTOs;
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
        Sirketler = new HashSet<DepartmentCompany>();
    }
    //navigation properties
    public ICollection<Personal>? Personeller { get; private set; }
    public ICollection<DepartmentCompany>? Sirketler { get; private set; }

    public static Department CreateDepartment(DepartmentDTO departmentDTO) 
    {
        Department department = new(departmentDTO);
        department.UpdateBaseEntiy(null,DateTime.Now,null,Enums.Status.Added,null);
        return department;
    }

    public DepartmentDTO CreateDepartmentDTO() => new()
    {
        Id = this.Id,
        Name = this.Name.Value,
    };
    public static IEnumerable<DepartmentDTO> CreateDepartmentDTOs(IEnumerable<Department> departments)
    {
        List<DepartmentDTO> departmentDTOs = new List<DepartmentDTO>();
        foreach (Department department in departments)
            departmentDTOs.Add(new DepartmentDTO()
            {
                Id = department.Id,
                Name = department.Name.Value,
            });
        return departmentDTOs;
    }
    public Task SoftDeleteDepartment()
    {
        UpdateDeleteDate(DateTime.Now);
         UpdateBaseEntiy(null, null, null, Enums.Status.Deleted, null);
      
        return Task.CompletedTask;
    }
    public Task UpdateDepartment(DepartmentUpdateDTO departmentUpdateDTO)
    {
        UpdateBaseEntiy(new(departmentUpdateDTO.Name), null, departmentUpdateDTO.Id, Enums.Status.Modified, DateTime.Now);
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
            Sirketler.Add(company);
        }

        return Task.CompletedTask;
    }

}
