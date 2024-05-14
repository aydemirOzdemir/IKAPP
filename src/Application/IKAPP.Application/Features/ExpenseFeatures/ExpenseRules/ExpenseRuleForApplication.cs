using IKAPP.Application.Bases;
using IKAPP.Application.Features.AdvanceFeatures.AdvanceExceptions;
using IKAPP.Application.Features.DepartmentFeatures.DepartmentExceptions;
using IKAPP.Application.Features.ExpenseFeatures.ExpenseExceptions;
using IKAPP.Domain.Entities.AggregateModels.Advances;
using IKAPP.Domain.Entities.AggregateModels.Departments;
using IKAPP.Domain.Entities.AggregateModels.Expenses;
using IKAPP.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Application.Features.ExpenseFeatures.ExpenseRules;

public class ExpenseRuleForApplication:BaseRuleForApplication
{
    public Task ExpenseShouldNotBeNull(Expense? expense, string message)
    {
        if (expense == null)
            throw new ExpenseShouldNotBeNullException(message);
        return Task.CompletedTask;
    }
    public Task CanNotCancelApprovedOrRejectedExpenses(Expense? expense)
    {
        if (expense.StatusofApproval != Approval.AwaitingApproval)
            throw new CanNotCancelApprovedOrRejectedExpensesException("Onaylanmış veya reddedilmiş avansları iptal edemezsiniz.");
        return Task.CompletedTask;
    }

}
