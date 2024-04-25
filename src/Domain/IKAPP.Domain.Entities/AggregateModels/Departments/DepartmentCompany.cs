using IKAPP.Domain.Entities.AggregateModels.Companies;
using IKAPP.Domain.Entities.AggregateModels.Departments.DepartmentDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Domain.Entities.AggregateModels.Departments;

public class DepartmentCompany
{
    private DepartmentCompany(DepartmentCompanyDTO departmentCompanyDTO)
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

    public static DepartmentCompany CreateDepartmentCompany(DepartmentCompanyDTO departmentCompanyDTO) => new(departmentCompanyDTO);


    public DepartmentCompanyDTO CreateDepartmentCompanyDTO() => new()
    {
        Id = this.Id,
        DepartmanId = this.DepartmanId,
        CompanyId = this.CompanyId,
        Department = this.Department,
        Company = this.Company
    };
    public Task UpdateDepartmentCompany(DepartmentCompanyUpdateDTO departmentCompanyUpdateDTO)
    {
        Id = departmentCompanyUpdateDTO.Id;
        CompanyId = departmentCompanyUpdateDTO.CompanyId;
        DepartmanId = departmentCompanyUpdateDTO.DepartmanId;
        return Task.CompletedTask;
    }


}
