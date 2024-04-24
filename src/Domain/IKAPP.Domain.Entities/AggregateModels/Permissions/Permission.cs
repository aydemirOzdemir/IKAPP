using IKAPP.Domain.Entities.AggregateModels.Companies;
using IKAPP.Domain.Entities.AggregateModels.Permissions.PermissionDTOs;
using IKAPP.Domain.Entities.AggregateModels.Permissions.PermissionRules;
using IKAPP.Domain.Entities.AggregateModels.Permissions.PermissionValueObjects;
using IKAPP.Domain.Entities.AggregateModels.Personals;
using IKAPP.Domain.Entities.AggregateModels.TypeofPermissions;
using IKAPP.Domain.Entities.SeedWorks;
using IKAPP.Domain.Entities.SeedWorks.Base;
using IKAPP.Domain.SeedWorks.Base.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Domain.Entities.AggregateModels.Permissions;

public  class Permission:BaseEntityForBusiness,IAggregateRoot
{
    private readonly PermissionRule rules;

    public Permission(PermissionDTO permissionDTO) : base(permissionDTO.Id, new(permissionDTO.Name))
    {
        rules = new();
        rules.PersonalIdCanNotBeEmpty(permissionDTO.PersonalId);
        PersonalId = permissionDTO.PersonalId;
        rules.TypeofPermissionIdCanNotBeEmpty(permissionDTO.TypeofPermissionId);
        TypeofPermissionId= permissionDTO.TypeofPermissionId;
        CompanyId= permissionDTO.CompanyId;
        rules.PermissionTimeCanNotBeEmpty(new(permissionDTO.StartedDate,permissionDTO.FinishedDate,permissionDTO.DayCount));
        PermissionTime = new(permissionDTO.StartedDate, permissionDTO.FinishedDate, permissionDTO.DayCount);
        rules.PersonalCanNotBeEmpty(permissionDTO.Personal);
        Personal = permissionDTO.Personal;
        rules.TypeofPermissionCanNotBeEmpty(permissionDTO.TypeofPermission);
        TypeofPermission= permissionDTO.TypeofPermission;
    }
    public PermissionTime PermissionTime { get;private set; }
    public string TypeofPermissionId { get; private set; }
    public string PersonalId { get;private set; }
    public string? CompanyId { get;private set; }

    //NavigationPropertiy
    public TypeofPermission TypeofPermission { get;private set; }
    public Personal Personal { get;private set; }
    public Company? Company { get;private set; }
  
}
