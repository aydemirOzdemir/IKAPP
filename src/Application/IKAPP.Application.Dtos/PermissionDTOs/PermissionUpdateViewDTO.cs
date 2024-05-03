using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Application.Dtos.PermissionDTOs;

public class PermissionUpdateViewDTO
{
    public string Id { get; set; }
    public string? Name { get; set; }
    public DateTime StartedDate { get; set; }

    public string TypeofPermissionId { get; set; }
}
