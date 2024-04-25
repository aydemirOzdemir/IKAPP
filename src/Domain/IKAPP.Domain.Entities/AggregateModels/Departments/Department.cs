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
        Şiketler = new HashSet<DepartmentCompany>();
    }
    //navigation properties
    public ICollection<Personal>? Personeller { get; private set; }
    public ICollection<DepartmentCompany>? Şiketler { get; private set; }

    public Department CreateDepartment(DepartmentDTO departmentDTO) => new(departmentDTO) { CreatedDate = DateTime.Now };

    public DepartmentDTO CreateDepartmentDTO() => new()
    {
        Id = this.Id,
        Name = this.Name.Value,
    };

}
