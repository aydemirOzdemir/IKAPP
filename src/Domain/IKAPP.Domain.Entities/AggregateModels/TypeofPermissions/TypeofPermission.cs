using IKAPP.Domain.Entities.AggregateModels.Permissions;
using IKAPP.Domain.Entities.AggregateModels.TypeofPermissions.TypeofPermissionDTOs;
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

    public TypeofPermission(TypeOfPermissionDTO typeOfPermissionDTO) : base(typeOfPermissionDTO.Id,new( typeOfPermissionDTO.Name))
    {
        Permissions = new HashSet<Permission>();
        rules = new();
        rules.DurationCanNotBeEmpty(typeOfPermissionDTO.Duration);
        Duration = typeOfPermissionDTO.Duration;
        rules.GenderCanNotBeEmpty(typeOfPermissionDTO.Gender);
        Gender= typeOfPermissionDTO.Gender;
    }
    public byte Duration { get; private set; }
    public Gender Gender { get; private set; }
    public ICollection<Permission> Permissions { get;private set; }

    public static TypeofPermission CreateTypeOfPermission(TypeOfPermissionDTO typeOfPermissionDTO) => new(typeOfPermissionDTO) { CreatedDate=DateTime.Now };
    public TypeOfPermissionDTO CreateTypeOfPermissionDTO() => new()
    {
        Id = this.Id,
        Name = this.Name.Value,
        Duration = this.Duration,
        Gender = this.Gender,
    };
    public Task SoftDeleteTypeOfPermission()
    {
        IsActive = false;
        DeletedDate = DateTime.Now;
        return Task.CompletedTask;
    }
    public Task UpdateTypeOfPermission(TypeOfPermissionUpdateDTO typeOfPermissionUpdateDTO)
    {
        Id=typeOfPermissionUpdateDTO.Id;
        Name = new(typeOfPermissionUpdateDTO.Name);
        Duration = typeOfPermissionUpdateDTO.Duration;
        Gender = typeOfPermissionUpdateDTO.Gender;
        ModifiedDate = DateTime.Now;
        return Task.CompletedTask;
    }
}


