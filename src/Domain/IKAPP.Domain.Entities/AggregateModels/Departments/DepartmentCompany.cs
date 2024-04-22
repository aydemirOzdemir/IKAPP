using IKAPP.Domain.Entities.AggregateModels.Companies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Domain.Entities.AggregateModels.Departments;

public  class DepartmentCompany
{
    public DepartmentCompany(string id,string departmanId,string companyId,Department? department,Company? company)
    {
        Id = id;
        Department = department;
        Company = company;
        DepartmanId = departmanId;
        CompanyId = companyId;
    }
    public string Id { get; set; }
    public string DepartmanId { get; set; }
    public string CompanyId { get; set; }

    //navigation properties
    public virtual Department? Department { get; set; }//departman Entity
    public virtual Company? Company { get; set; } //Şirket Entity
}
