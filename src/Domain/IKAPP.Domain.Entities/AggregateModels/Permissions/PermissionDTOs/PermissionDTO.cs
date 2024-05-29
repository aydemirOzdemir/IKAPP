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
    public string Id { get; set; } = null!;
    public DateTime? RequestDate { get; set; }=default!;
    public string Name { get; set; } = null!;
    public DateTime StartedDate { get; set; } = default!;
    public DateTime FinishedDate { get; set; } = default!;
    public byte DayCount { get; set; } = default!;
    public DateTime? DateofReply { get; set; }
    public Approval? StatusofApproval { get; set; }

    public string TypeofPermissionId { get; set; } = null!;
    public string PersonalId { get; set; } = null!;
    public string? CompanyId { get; set; }
    public TypeofPermission TypeofPermission { get; set; } = null!;
    public Personal Personal { get; set; } = null!;
    public Company? Company { get; set; }
}
