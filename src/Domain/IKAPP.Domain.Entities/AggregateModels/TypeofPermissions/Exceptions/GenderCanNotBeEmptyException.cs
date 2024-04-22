using IKAPP.Domain.Entities.Bases;

namespace IKAPP.Domain.Entities.AggregateModels.TypeofPermissions.Exceptions;

public class GenderCanNotBeEmptyException : BaseException
{
    public GenderCanNotBeEmptyException(string message) : base(message)
    { }
}
