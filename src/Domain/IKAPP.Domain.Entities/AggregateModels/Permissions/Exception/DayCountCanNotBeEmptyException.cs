using IKAPP.Domain.Entities.Bases;

namespace IKAPP.Domain.Entities.AggregateModels.Permissions.Exception;

public class DayCountCanNotBeEmptyException : BaseException
{
    public DayCountCanNotBeEmptyException(string message) : base(message)
    { }
}
