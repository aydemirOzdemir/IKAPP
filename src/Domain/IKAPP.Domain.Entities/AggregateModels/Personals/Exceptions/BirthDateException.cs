using IKAPP.Domain.Entities.Bases;

namespace IKAPP.Domain.Entities.AggregateModels.Personals.Exceptions;

public class BirthDateException : BaseException
{
    public BirthDateException(string message) : base(message)
    { }
}

