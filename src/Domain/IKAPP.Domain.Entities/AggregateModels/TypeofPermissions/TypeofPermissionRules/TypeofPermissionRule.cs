using IKAPP.Domain.Entities.AggregateModels.Advances.Exceptions;
using IKAPP.Domain.Entities.AggregateModels.TypeofPermissions.Exceptions;
using IKAPP.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Domain.Entities.AggregateModels.TypeofPermissions.TypeofPermissionRules;

public class TypeofPermissionRule
{
    public Task DurationCanNotBeEmpty(byte? value)
    {
        if (value == null)
        {
            throw new DurationCanNotBeEmptyException("İzin Türü Süresi Alanı Boş Bırakılamaz");
        }
        return Task.CompletedTask;
    }
    public Task GenderCanNotBeEmpty(Gender? value)
    {
        if (value == null)
        {
            throw new GenderCanNotBeEmptyException("İzin Cinsiyeti Alanı Boş Bırakılamaz");
        }
        return Task.CompletedTask;
    }
}
