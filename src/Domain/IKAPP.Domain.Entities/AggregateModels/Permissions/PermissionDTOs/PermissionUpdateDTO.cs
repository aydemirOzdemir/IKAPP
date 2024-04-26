using IKAPP.Domain.Entities.AggregateModels.TypeofPermissions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Domain.Entities.AggregateModels.Permissions.PermissionDTOs;

public sealed record PermissionUpdateDTO
{
    public string Id { get; set; } = null!;

    public DateTime StartedDate { get; set; } = default!;
    public DateTime FinishedDate { get; init; } = default!;
    public byte DayCount { get; init; } = default!;

    public string TypeofPermissionId { get; set; } = default!;
    public TypeofPermission TypeofPermission { get; set; } = null!;
}
