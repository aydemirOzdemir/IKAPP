using IKAPP.Domain.Entities.Bases;

namespace IKAPP.Domain.Entities.AggregateModels.Permissions.Exception;

public class StartedDateCanNotBeEmptyException : BaseException
{
    public StartedDateCanNotBeEmptyException(string message) : base(message)
    { }
}
