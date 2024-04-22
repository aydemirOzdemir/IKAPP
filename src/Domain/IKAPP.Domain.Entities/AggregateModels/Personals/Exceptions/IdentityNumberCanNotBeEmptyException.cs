using IKAPP.Domain.Entities.Bases;

namespace IKAPP.Domain.Entities.AggregateModels.Personals.Exceptions;

public class IdentityNumberCanNotBeEmptyException : BaseException
{
    public IdentityNumberCanNotBeEmptyException(string message) : base(message)
    { }
}
