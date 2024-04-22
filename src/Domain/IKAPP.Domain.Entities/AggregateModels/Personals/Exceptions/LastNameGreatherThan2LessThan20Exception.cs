using IKAPP.Domain.Entities.Bases;

namespace IKAPP.Domain.Entities.AggregateModels.Personals.Exceptions;

public class LastNameGreatherThan2LessThan20Exception : BaseException
{
    public LastNameGreatherThan2LessThan20Exception(string message) : base(message)
    { }
}

