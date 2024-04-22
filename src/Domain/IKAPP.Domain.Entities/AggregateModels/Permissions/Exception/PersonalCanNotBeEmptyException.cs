using IKAPP.Domain.Entities.Bases;

namespace IKAPP.Domain.Entities.AggregateModels.Permissions.Exception;

public class PersonalCanNotBeEmptyException : BaseException
{
    public PersonalCanNotBeEmptyException(string message) : base(message)
    { }
}
