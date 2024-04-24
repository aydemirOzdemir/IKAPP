using IKAPP.Domain.Entities.AggregateModels.Companies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Domain.Entities.AggregateModels.Departments.DepartmentDTOs;

public sealed record DepartmentCompanyDTO
{
    public string Id { get; init; }
    public string DepartmanId { get; init; }
    public string CompanyId { get; init; }

    //navigation properties
    public  Department? Department { get; init; }//departman Entity
    public  Company? Company { get; init; } //Şirket Entity
}
