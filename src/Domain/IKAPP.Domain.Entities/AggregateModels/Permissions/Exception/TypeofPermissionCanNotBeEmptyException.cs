using IKAPP.Domain.Entities.Bases;

namespace IKAPP.Domain.Entities.AggregateModels.Permissions.Exception;

public class TypeofPermissionCanNotBeEmptyException : BaseException
{
    public TypeofPermissionCanNotBeEmptyException(string message) : base(message)
    { }
}
