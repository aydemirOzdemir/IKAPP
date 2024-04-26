using IKAPP.Domain.Entities.Enums;
using IKAPP.Domain.SeedWorks.Base.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Domain.Entities.AggregateModels.TypeofPermissions.TypeofPermissionDTOs;

public sealed record TypeOfPermissionDTO
{
    public string Id { get; set; } = null!;
    public string Name { get;  set; } = null!;
    public byte Duration { get;  set; } = default!;
    public Gender Gender { get;  set; } = default!;
}
