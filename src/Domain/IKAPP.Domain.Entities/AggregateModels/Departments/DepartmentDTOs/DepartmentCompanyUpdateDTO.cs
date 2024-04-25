using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Domain.Entities.AggregateModels.Departments.DepartmentDTOs;

public sealed record DepartmentCompanyUpdateDTO
{
    public string Id { get; set; }
    public string DepartmanId { get; set; }
    public string CompanyId { get; set; }
}
