using IKAPP.Domain.Entities.Bases;

namespace IKAPP.Domain.Entities.AggregateModels.Permissions.Exception;

public class FinishedDateCanNotBeEmptyException : BaseException
{
    public FinishedDateCanNotBeEmptyException(string message) : base(message)
    { }
}
