using IKAPP.Domain.SeedWorks.Base.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Domain.Entities.AggregateModels.Departments.DepartmentDTOs;

public sealed record DepartmentDTO
{
    public string Name { get; set; } = null!;
    public string Id { get; set; } = null!;
}
