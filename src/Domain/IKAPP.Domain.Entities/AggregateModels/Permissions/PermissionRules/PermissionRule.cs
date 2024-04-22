using IKAPP.Domain.Entities.AggregateModels.Advances.Exceptions;
using IKAPP.Domain.Entities.AggregateModels.Permissions.Exception;
using IKAPP.Domain.Entities.AggregateModels.Permissions.PermissionValueObjects;
using IKAPP.Domain.Entities.AggregateModels.Personals;
using IKAPP.Domain.Entities.AggregateModels.TypeofPermissions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Domain.Entities.AggregateModels.Permissions.PermissionRules;

public class PermissionRule
{
    public Task PersonalIdCanNotBeEmpty(string value)
    {
        if (value == null)
        {
            throw new PersonalIdCanNotBeEmptyException("Personel Kimliği Alanı Boş Bırakılamaz");
        }
        return Task.CompletedTask;
    }
    public Task TypeofPermissionIdCanNotBeEmpty(string value)
    {
        if (value == null)
        {
            throw new TypeofPermissionIdCanNotBeEmptyException("İzin Türü  Kimliği Alanı Boş Bırakılamaz");
        }
        return Task.CompletedTask;
    }
    public Task StartedDateCanNotBeEmpty(DateTime? value)
    {
        if (value == null)
        {
            throw new StartedDateCanNotBeEmptyException("İzin Başlangıç Günü Alanı Boş Bırakılamaz");
        }
        return Task.CompletedTask;
    }
    public Task FinishedDateCanNotBeEmpty(DateTime? value)
    {
        if (value == null)
        {
            throw new FinishedDateCanNotBeEmptyException("İzin Başlangıç Günü Alanı Boş Bırakılamaz");
        }
        return Task.CompletedTask;
    }
    public Task DayCountCanNotBeEmpty(byte? value)
    {
        if (value == null)
        {
            throw new DayCountCanNotBeEmptyException("İzin Günü Sayısı Alanı Boş Bırakılamaz");
        }
        return Task.CompletedTask;
    }
    public Task PersonalCanNotBeEmpty(Personal? value)
    {
        if (value == null)
        {
            throw new PersonalCanNotBeEmptyException("Personal Alanı Boş Bırakılamaz");
        }
        return Task.CompletedTask;
    }
    public Task TypeofPermissionCanNotBeEmpty(TypeofPermission? value)
    {
        if (value == null)
        {
            throw new TypeofPermissionCanNotBeEmptyException("İzin Türü Alanı Boş Bırakılamaz");
        }
        return Task.CompletedTask;
    }
    public Task PermissionTimeCanNotBeEmpty(PermissionTime? value)
    {
        if (value == null)
        {
            throw new PermissionTimeCanNotBeEmptyException("İzin Süresi Alanı Boş Bırakılamaz");
        }
        return Task.CompletedTask;
    }
}
