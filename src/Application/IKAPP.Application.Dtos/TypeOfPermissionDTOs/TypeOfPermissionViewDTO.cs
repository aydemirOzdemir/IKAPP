using IKAPP.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Application.Dtos.TypeOfPermissionDTOs;

public class TypeOfPermissionViewDTO
{
    public string Id { get; set; }
    public string Name { get; set; } = default!;
    public byte Duration { get; set; }
    public Gender Gender { get; set; }
}
