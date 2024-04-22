using IKAPP.Domain.Entities.Bases;

namespace IKAPP.Domain.Entities.AggregateModels.Advances.Exceptions;

public class DescriptionCanNotBeEmptyException : BaseException
{
    public DescriptionCanNotBeEmptyException(string message) : base(message)
    { }
}
