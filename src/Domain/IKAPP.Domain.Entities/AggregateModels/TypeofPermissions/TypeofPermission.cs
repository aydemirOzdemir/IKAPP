using IKAPP.Domain.Entities.AggregateModels.Permissions;
using IKAPP.Domain.Entities.AggregateModels.TypeofPermissions.TypeofPermissionRules;
using IKAPP.Domain.Entities.Enums;
using IKAPP.Domain.Entities.SeedWorks;
using IKAPP.Domain.Entities.SeedWorks.Base;
using IKAPP.Domain.SeedWorks.Base.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Domain.Entities.AggregateModels.TypeofPermissions;

public  class TypeofPermission:AuditableEntity,IAggregateRoot
{
    private readonly TypeofPermissionRule rules;

    public TypeofPermission(string id, Name name,byte duration,Gender gender) : base(id, name)
    {
        Permissions = new HashSet<Permission>();
        rules = new();
        rules.DurationCanNotBeEmpty(duration);
        Duration = duration;
        rules.GenderCanNotBeEmpty(gender);
        Gender= gender;
    }
    public byte Duration { get; private set; }
    public Gender Gender { get; private set; }
    public ICollection<Permission> Permissions { get;private set; }
}
