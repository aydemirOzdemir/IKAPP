using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Application.Dtos.DepartmentDTOs;

public class DepartmentViewDTO
{
    public string Id { get; set; } = default!;
    public string Name { get; set; } = default!;
    public bool IsActive { get; set; }
}
