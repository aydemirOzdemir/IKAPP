using IKAPP.Domain.Entities.Bases;

namespace IKAPP.Domain.Entities.AggregateModels.Personals.Exceptions;

public class AddressCanNotBeEmptyException : BaseException
{
    public AddressCanNotBeEmptyException(string message) : base(message)
    { }
}

