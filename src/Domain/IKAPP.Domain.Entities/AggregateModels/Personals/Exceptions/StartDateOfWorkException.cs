using IKAPP.Domain.Entities.Bases;

namespace IKAPP.Domain.Entities.AggregateModels.Personals.Exceptions;

public class StartDateOfWorkException : BaseException
{
    public StartDateOfWorkException(string message) : base(message)
    { }
}

