using IKAPP.Domain.Entities.Bases;

namespace IKAPP.Domain.Entities.AggregateModels.Personals.Exceptions;

public class IdentityNumberLengthMustBe11Exception : BaseException
{
    public IdentityNumberLengthMustBe11Exception(string message) : base(message)
    { }
}
