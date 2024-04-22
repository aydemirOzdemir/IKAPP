using IKAPP.Domain.Entities.Bases;

namespace IKAPP.Domain.Entities.AggregateModels.Personals.Exceptions;

public class LastNameCanNotBeEmptyException : BaseException
{
    public LastNameCanNotBeEmptyException(string message) : base(message)
    { }
}
