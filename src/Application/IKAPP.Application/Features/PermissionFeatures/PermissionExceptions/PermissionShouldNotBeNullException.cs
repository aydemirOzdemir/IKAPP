using IKAPP.Application.Bases;
using IKAPP.Domain.Entities.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Application.Features.PermissionFeatures.PermissionExceptions;

public class PermissionShouldNotBeNullException:BaseException
{
    public PermissionShouldNotBeNullException(string message):base(message)
    {}
}
