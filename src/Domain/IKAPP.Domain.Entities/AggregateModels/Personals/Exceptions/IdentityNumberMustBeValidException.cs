using IKAPP.Domain.Entities.Bases;

namespace IKAPP.Domain.Entities.AggregateModels.Personals.Exceptions;

public class IdentityNumberMustBeValidException : BaseException
{
    public IdentityNumberMustBeValidException(string message) : base(message)
    { }
}
