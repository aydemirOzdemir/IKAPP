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
    public string Id { get; init; }
    public DateTime RequestDate { get; init; }
    public string Name { get; init; }
    public DateTime StartedDate { get; init; }
    public DateTime FinishedDate { get; init; }
    public byte DayCount { get; init; }
    public DateTime DateofReply { get; init; }
    public Approval StatusofApproval { get; init; }
  
    public string TypeofPermissionId { get;  init; }
    public string PersonalId { get;  init; }
    public string? CompanyId { get;  init; }
    public TypeofPermission TypeofPermission { get;  init; }
    public Personal Personal { get;  init; }
    public Company? Company { get;  init; }
}
