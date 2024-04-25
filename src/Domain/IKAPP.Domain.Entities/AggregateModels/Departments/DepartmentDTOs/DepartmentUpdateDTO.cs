using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Domain.Entities.AggregateModels.Departments.DepartmentDTOs;

public sealed record DepartmentUpdateDTO
{
    public string Id { get; set; } = default!;
    public string Name { get; set; } = default!;
}
