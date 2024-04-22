using IKAPP.Domain.Entities.Bases;

namespace IKAPP.Domain.Entities.AggregateModels.Advances.Exceptions;

public class TypeofAdvanceCanNotBeEmptyException : BaseException
{
    public TypeofAdvanceCanNotBeEmptyException(string message) : base(message)
    { }
}
