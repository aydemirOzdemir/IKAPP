using IKAPP.Domain.Entities.AggregateModels.Companies;
using IKAPP.Domain.Entities.AggregateModels.Permissions.PermissionDTOs;
using IKAPP.Domain.Entities.AggregateModels.Permissions.PermissionRules;
using IKAPP.Domain.Entities.AggregateModels.Permissions.PermissionValueObjects;
using IKAPP.Domain.Entities.AggregateModels.Personals;
using IKAPP.Domain.Entities.AggregateModels.TypeofPermissions;
using IKAPP.Domain.Entities.Enums;
using IKAPP.Domain.Entities.SeedWorks;
using IKAPP.Domain.Entities.SeedWorks.Base;
using IKAPP.Domain.SeedWorks.Base.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Domain.Entities.AggregateModels.Permissions;

public class Permission : BaseEntityForBusiness, IAggregateRoot
{
    private readonly PermissionRule rules;

    private Permission(PermissionDTO permissionDTO) : base(permissionDTO.Id, new(permissionDTO.Name))
    {
        rules = new();
        rules.PersonalIdCanNotBeEmpty(permissionDTO.PersonalId);
        PersonalId = permissionDTO.PersonalId;
        rules.TypeofPermissionIdCanNotBeEmpty(permissionDTO.TypeofPermissionId);
        TypeofPermissionId = permissionDTO.TypeofPermissionId;
        CompanyId = permissionDTO.CompanyId;
        rules.PermissionTimeCanNotBeEmpty(new(permissionDTO.StartedDate, permissionDTO.FinishedDate, permissionDTO.DayCount));
        PermissionTime = new(permissionDTO.StartedDate, permissionDTO.FinishedDate, permissionDTO.DayCount);
        rules.PersonalCanNotBeEmpty(permissionDTO.Personal);
        Personal = permissionDTO.Personal;
        rules.TypeofPermissionCanNotBeEmpty(permissionDTO.TypeofPermission);
        TypeofPermission = permissionDTO.TypeofPermission;
    }
    public PermissionTime PermissionTime { get; private set; }
    public string TypeofPermissionId { get; private set; }
    public string PersonalId { get; private set; }
    public string? CompanyId { get; private set; }

    //NavigationPropertiy
    public TypeofPermission TypeofPermission { get; private set; }
    public Personal Personal { get; private set; }
    public Company? Company { get; private set; }
    public static Permission CreatePermission(PermissionDTO permissionDTO) => new(permissionDTO) { CreatedDate = DateTime.Now,Status=Status.Added };

    public PermissionDTO CreatePermissionDTO() => new()
    {
        Id = this.Id,
        RequestDate = this.RequestDate,
        Name = this.Name.Value,
        StartedDate = this.PermissionTime.StartedDate,
        FinishedDate = this.PermissionTime.FinishedDate,
        DayCount = this.PermissionTime.DayCount,
        DateofReply = this.DateofReply,
        StatusofApproval = this.StatusofApproval,
        TypeofPermissionId = this.TypeofPermissionId,
        PersonalId = this.PersonalId,
        CompanyId = this.CompanyId,
        TypeofPermission = this.TypeofPermission,
        Personal = this.Personal,
        Company = this.Company,

    };
    public Task SoftDeletePermission()
    {
        IsActive = false;
        DeletedDate = DateTime.Now;
        Status=Status.Deleted;
        return Task.CompletedTask;
    }
    public Task UpdatePermission(PermissionUpdateDTO permissionUpdateDTO)
    {
        Id = permissionUpdateDTO.Id;
        PermissionTime = new(permissionUpdateDTO.StartedDate,permissionUpdateDTO.FinishedDate,permissionUpdateDTO.DayCount);
        TypeofPermissionId= permissionUpdateDTO.TypeofPermissionId;
        TypeofPermission = TypeofPermission;
        ModifiedDate=DateTime.Now;
        Status = Status.Modified;
        return  Task.CompletedTask;
    }


}