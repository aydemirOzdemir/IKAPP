using IKAPP.Domain.Entities.Bases;

namespace IKAPP.Application.Features.AdvanceFeatures.AdvanceExceptions;

public class CanNotCancelApprovedOrRejectedAdvancesException : BaseException
{
    public CanNotCancelApprovedOrRejectedAdvancesException(string message) : base(message)
    { }
}
public class AdvanceDoesNotUpdatedException : BaseException
{
    public AdvanceDoesNotUpdatedException(string message) : base(message)
    { }
}
