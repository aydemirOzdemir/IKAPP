using IKAPP.Domain.Entities.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Application.Features.DepartmentFeatures.DepartmentExceptions;

public class DepartmentShouldNotBeNullException:BaseException
{
    public DepartmentShouldNotBeNullException(string message):base(message)
    { }
}
