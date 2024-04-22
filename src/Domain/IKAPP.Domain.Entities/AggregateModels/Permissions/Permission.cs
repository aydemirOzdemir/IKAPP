using IKAPP.Domain.Entities.AggregateModels.Companies;
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

    public Permission(string id, Name name,PermissionTime permissionTime,string personalId,string typeOfPermissionId,string? companyId,TypeofPermission typeofPermission,Personal personal,Company? company) : base(id, name)
    {
        rules = new();
        rules.PersonalIdCanNotBeEmpty(personalId);
        PersonalId = personalId;
        rules.TypeofPermissionIdCanNotBeEmpty(typeOfPermissionId);
        TypeofPermissionId= typeOfPermissionId;
        CompanyId= companyId;
        rules.PermissionTimeCanNotBeEmpty(permissionTime);
        PermissionTime = permissionTime;
        rules.PersonalCanNotBeEmpty(personal);
        Personal = personal;
        rules.TypeofPermissionCanNotBeEmpty(typeofPermission);
        TypeofPermission= typeofPermission;
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
