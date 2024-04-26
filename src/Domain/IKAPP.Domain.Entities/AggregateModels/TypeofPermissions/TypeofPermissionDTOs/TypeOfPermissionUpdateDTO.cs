using IKAPP.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Domain.Entities.AggregateModels.TypeofPermissions.TypeofPermissionDTOs;

public sealed record TypeOfPermissionUpdateDTO
{
    public string Id { get; set; } = null!;
    public string Name { get; set; } = default!;
    public byte Duration { get; set; } = default!;
    public Gender Gender { get; set; } = default!;
}
