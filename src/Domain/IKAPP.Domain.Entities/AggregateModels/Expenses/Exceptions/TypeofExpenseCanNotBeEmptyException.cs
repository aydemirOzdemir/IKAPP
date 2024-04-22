using IKAPP.Domain.Entities.Bases;

namespace IKAPP.Domain.Entities.AggregateModels.Expenses.Exceptions;

public class TypeofExpenseCanNotBeEmptyException : BaseException
{
    public TypeofExpenseCanNotBeEmptyException(string message) : base(message)
    { }
}
