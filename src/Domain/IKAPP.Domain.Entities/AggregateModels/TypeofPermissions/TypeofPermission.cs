using IKAPP.Domain.Entities.AggregateModels.Companies.CompanyDTOs;
using IKAPP.Domain.Entities.AggregateModels.Permissions;
using IKAPP.Domain.Entities.AggregateModels.Permissions.PermissionDTOs;
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

    public static TypeofPermission CreateTypeOfPermission(TypeOfPermissionDTO typeOfPermissionDTO) 
    {
        TypeofPermission typeofPermission = new(typeOfPermissionDTO);
        typeofPermission.UpdateBaseEntiy(null, DateTime.Now, null, Enums.Status.Added, null);
        return typeofPermission;
    }
    public TypeOfPermissionDTO CreateTypeOfPermissionDTO() => new()
    {
        Id = this.Id,
        Name = this.Name.Value,
        Duration = this.Duration,
        Gender = this.Gender,
    };
    public static IEnumerable<TypeOfPermissionDTO> CreateTypeOfPermissionDTOs(IEnumerable<TypeofPermission> permissions)
    {
        List<TypeOfPermissionDTO> permissionDTOs = new List<TypeOfPermissionDTO>();
        foreach (TypeofPermission permission in permissions)
            permissionDTOs.Add(new TypeOfPermissionDTO()
            {
                Id = permission.Id,
                Name = permission.Name.Value,
                Duration = permission.Duration,
                Gender = permission.Gender,
            });
        return permissionDTOs;
    }
    public Task SoftDeleteTypeOfPermission()
    {

        UpdateDeleteDate(DateTime.Now);
        UpdateBaseEntiy(null, null, null, Enums.Status.Deleted, null);
        return Task.CompletedTask;
    }
    public Task UpdateTypeOfPermission(TypeOfPermissionUpdateDTO typeOfPermissionUpdateDTO)
    {
        
        Duration = typeOfPermissionUpdateDTO.Duration;
        Gender = typeOfPermissionUpdateDTO.Gender;
        UpdateBaseEntiy(new(typeOfPermissionUpdateDTO.Name), null, typeOfPermissionUpdateDTO.Id, Enums.Status.Modified, DateTime.Now);
        return Task.CompletedTask;
    }
    public Task AddPermissions(List<Permission> permissions)
    {
        foreach (Permission permission in permissions)
        {
            Permissions.Add(permission);
        }

        return Task.CompletedTask;
    }
}


