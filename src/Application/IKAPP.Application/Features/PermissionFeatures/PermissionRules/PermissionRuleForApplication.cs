using IKAPP.Application.Bases;
using IKAPP.Application.Features.ExpenseFeatures.ExpenseExceptions;
using IKAPP.Application.Features.PermissionFeatures.PermissionExceptions;
using IKAPP.Domain.Entities.AggregateModels.Expenses;
using IKAPP.Domain.Entities.AggregateModels.Permissions;
using IKAPP.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Application.Features.PermissionFeatures.PermissionRules;

public class PermissionRuleForApplication:BaseRuleForApplication
{
    public Task PermissionShouldNotBeNull(Permission? permission, string message)
    {
        if (permission == null)
            throw new PermissionShouldNotBeNullException(message);
        return Task.CompletedTask;
    }
    public Task CanNotCancelApprovedOrRejectedPermissions(Permission? permission)
    {
        if (permission.StatusofApproval != Approval.AwaitingApproval)
            throw new CanNotCancelApprovedOrRejectedPermissionsException("Onaylanmış veya reddedilmiş avansları iptal edemezsiniz.");
        return Task.CompletedTask;
    }
}
