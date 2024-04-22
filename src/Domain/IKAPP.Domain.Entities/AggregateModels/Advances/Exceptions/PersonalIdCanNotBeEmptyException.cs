using IKAPP.Domain.Entities.Bases;

namespace IKAPP.Domain.Entities.AggregateModels.Advances.Exceptions;

public class PersonalIdCanNotBeEmptyException : BaseException
{
    public PersonalIdCanNotBeEmptyException(string message) : base(message)
    { }
}
