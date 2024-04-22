using IKAPP.Domain.Entities.Bases;

namespace IKAPP.Domain.Entities.AggregateModels.Personals.Exceptions;

public class VocationException : BaseException
{
    public VocationException(string message) : base(message)
    { }
}

