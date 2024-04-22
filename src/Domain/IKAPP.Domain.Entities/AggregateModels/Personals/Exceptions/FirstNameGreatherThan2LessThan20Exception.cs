using IKAPP.Domain.Entities.Bases;

namespace IKAPP.Domain.Entities.AggregateModels.Personals.Exceptions;

public class FirstNameGreatherThan2LessThan20Exception : BaseException
{
    public FirstNameGreatherThan2LessThan20Exception(string message) : base(message)
    { }
}
