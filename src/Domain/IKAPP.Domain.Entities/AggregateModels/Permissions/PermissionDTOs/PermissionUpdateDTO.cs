using IKAPP.Domain.Entities.AggregateModels.TypeofPermissions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Domain.Entities.AggregateModels.Permissions.PermissionDTOs;

public sealed record PermissionUpdateDTO
{
    public string Id { get; set; }

    public DateTime StartedDate { get; set; }
    public DateTime FinishedDate { get; init; }
    public byte DayCount { get; init; }

    public string TypeofPermissionId { get; set; }
    public TypeofPermission TypeofPermission { get; set; }
}
