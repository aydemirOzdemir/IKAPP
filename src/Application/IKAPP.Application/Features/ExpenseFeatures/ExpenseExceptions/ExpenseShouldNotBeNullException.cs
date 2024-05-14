using IKAPP.Domain.Entities.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Application.Features.ExpenseFeatures.ExpenseExceptions;

public class ExpenseShouldNotBeNullException:BaseException
{
    public ExpenseShouldNotBeNullException(string message):base(message)
    {}
}
public class CanNotCancelApprovedOrRejectedExpensesException : BaseException
{
    public CanNotCancelApprovedOrRejectedExpensesException(string message) : base(message)
    { }
}
