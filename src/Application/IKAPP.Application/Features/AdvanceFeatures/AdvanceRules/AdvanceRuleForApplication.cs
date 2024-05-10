using IKAPP.Application.Bases;
using IKAPP.Application.Features.AdvanceFeatures.AdvanceExceptions;
using IKAPP.Domain.Entities.AggregateModels.Advances;
using IKAPP.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace IKAPP.Application.Features.AdvanceFeatures.AdvanceRules;

public class AdvanceRuleForApplication:BaseRuleForApplication
{
    public Task AdvanceMustNotBeNull(Advance? advance)
    {
        if (advance == null)
            throw new AdvanceMustNotBeNullException("Öğe Bulunamadı.");
        return Task.CompletedTask;
    }
    public Task AdvanceDoesNotUpdated(Advance? advance)
    {
        if (advance == null)
            throw new AdvanceDoesNotUpdatedException("Öğe güncellenemedi.");
        return Task.CompletedTask;
    }
    public Task CanNotCancelApprovedOrRejectedAdvances(Advance? advance)
    {
        if (advance.StatusofApproval != Approval.AwaitingApproval)
            throw new CanNotCancelApprovedOrRejectedAdvancesException("Onaylanmış veya reddedilmiş avansları iptal edemezsiniz.");
        return Task.CompletedTask;
    }

}
