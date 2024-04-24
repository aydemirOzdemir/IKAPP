using IKAPP.Domain.Entities.AggregateModels.Companies;
using IKAPP.Domain.Entities.AggregateModels.Departments.DepartmentDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Domain.Entities.AggregateModels.Departments;

public  class DepartmentCompany
{
    public DepartmentCompany(DepartmentCompanyDTO departmentCompanyDTO)
    {
        Id = departmentCompanyDTO.Id;
        Department = departmentCompanyDTO.Department;
        Company = departmentCompanyDTO.Company;
        DepartmanId = departmentCompanyDTO.DepartmanId;
        CompanyId = departmentCompanyDTO.CompanyId;
    }
    public string Id { get; private set; }
    public string DepartmanId { get; private set; }
    public string CompanyId { get; private set; }

    //navigation properties
    public virtual Department? Department { get; private set; }//departman Entity
    public virtual Company? Company { get; private set; } //Şirket Entity
}
