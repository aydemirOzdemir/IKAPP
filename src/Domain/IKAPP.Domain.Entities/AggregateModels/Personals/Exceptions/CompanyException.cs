using IKAPP.Domain.Entities.Bases;

namespace IKAPP.Domain.Entities.AggregateModels.Personals.Exceptions;

public class CompanyException : BaseException
{
    public CompanyException(string message) : base(message)
    { }
}

