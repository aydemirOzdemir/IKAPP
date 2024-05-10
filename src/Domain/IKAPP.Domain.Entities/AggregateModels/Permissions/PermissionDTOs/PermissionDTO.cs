using IKAPP.Domain.Entities.AggregateModels.Companies;
using IKAPP.Domain.Entities.AggregateModels.Permissions.PermissionValueObjects;
using IKAPP.Domain.Entities.AggregateModels.Personals;
using IKAPP.Domain.Entities.AggregateModels.TypeofPermissions;
using IKAPP.Domain.Entities.Enums;
using IKAPP.Domain.SeedWorks.Base.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Domain.Entities.AggregateModels.Permissions.PermissionDTOs;

public class PermissionDTO
{
    public string Id { get; init; } = null!;
    public DateTime? RequestDate { get; init; }=default!;
    public string Name { get; init; } = null!;
    public DateTime StartedDate { get; init; } = default!;
    public DateTime FinishedDate { get; init; } = default!;
    public byte DayCount { get; init; } = default!;
    public DateTime? DateofReply { get; init; }
    public Approval? StatusofApproval { get; init; }

    public string TypeofPermissionId { get; init; } = null!;
    public string PersonalId { get;  init; } = null!;
    public string? CompanyId { get;  init; }
    public TypeofPermission TypeofPermission { get;  init; } = null!;
    public Personal Personal { get;  init; } = null!;
    public Company? Company { get;  init; }
}
