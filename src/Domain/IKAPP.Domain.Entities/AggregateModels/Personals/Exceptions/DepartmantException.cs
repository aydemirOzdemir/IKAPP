using IKAPP.Domain.Entities.Bases;

namespace IKAPP.Domain.Entities.AggregateModels.Personals.Exceptions;

public class DepartmantException : BaseException
{
    public DepartmantException(string message) : base(message)
    { }
}

