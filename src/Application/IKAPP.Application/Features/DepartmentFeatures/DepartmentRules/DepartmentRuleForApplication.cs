using IKAPP.Application.Bases;
using IKAPP.Application.Features.DepartmentFeatures.DepartmentExceptions;
using IKAPP.Domain.Entities.AggregateModels.Departments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Application.Features.DepartmentFeatures.DepartmentRules;

public class DepartmentRuleForApplication:BaseRuleForApplication
{
    public Task DepartmentShouldNotBeNull(Department? department,string message )
    {
        if (department == null)
            throw new DepartmentShouldNotBeNullException(message);
        return Task.CompletedTask;
    }
}
