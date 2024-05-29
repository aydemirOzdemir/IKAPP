using IKAPP.Domain.Entities.Bases;

namespace IKAPP.Application.Features.PermissionFeatures.PermissionExceptions;

public class CanNotCancelApprovedOrRejectedPermissionsException : BaseException
{
    public CanNotCancelApprovedOrRejectedPermissionsException(string message) : base(message)
    { }
}
