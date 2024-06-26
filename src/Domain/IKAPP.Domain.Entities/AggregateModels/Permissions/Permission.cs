﻿using IKAPP.Domain.Entities.AggregateModels.Companies;
using IKAPP.Domain.Entities.AggregateModels.Expenses;
using IKAPP.Domain.Entities.AggregateModels.Expenses.ExpenseDTOs;
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
    public static Permission CreatePermission(PermissionDTO permissionDTO)
    {
        Permission permission = new(permissionDTO);
        permission.UpdateBaseEntiy(null,DateTime.Now,null,Enums.Status.Added,null);
        return permission;
    }

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

        UpdateDeleteDate(DateTime.Now);
        UpdateBaseEntiy(null, null, null, Enums.Status.Deleted, null);
        return Task.CompletedTask;
    }
    public static IEnumerable<PermissionDTO> CreatePermissionDTOs(IEnumerable<Permission> permissions)
    {
        List<PermissionDTO> permissionDTOs = new List<PermissionDTO>();
        foreach (Permission permission in permissions)
            permissionDTOs.Add(new PermissionDTO()
            {
                Id = permission.Id,
                RequestDate = permission.RequestDate,
                Name = permission.Name.Value,
                StartedDate = permission.PermissionTime.StartedDate,
                FinishedDate = permission.PermissionTime.FinishedDate,
                DayCount = permission.PermissionTime.DayCount,
                DateofReply = permission.DateofReply,
                StatusofApproval = permission.StatusofApproval,
                TypeofPermissionId = permission.TypeofPermissionId,
                PersonalId = permission.PersonalId,
                CompanyId = permission.CompanyId,
                TypeofPermission = permission.TypeofPermission,
                Personal = permission.Personal,
                Company = permission.Company,
            });
        return permissionDTOs;
    }
    public Task UpdatePermission(PermissionUpdateDTO permissionUpdateDTO)
    {
       
        PermissionTime = new(permissionUpdateDTO.StartedDate,permissionUpdateDTO.FinishedDate,permissionUpdateDTO.DayCount);
        TypeofPermissionId= permissionUpdateDTO.TypeofPermissionId;
        TypeofPermission = TypeofPermission;
        UpdateBaseEntiy(null, null, permissionUpdateDTO.Id, Enums.Status.Modified, DateTime.Now);
        return  Task.CompletedTask;
    }


}