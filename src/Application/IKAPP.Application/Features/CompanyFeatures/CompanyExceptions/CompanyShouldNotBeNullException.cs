using IKAPP.Domain.Entities.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Application.Features.CompanyFeatures.CompanyExceptions;

public class CompanyShouldNotBeNullException:BaseException
{
    public CompanyShouldNotBeNullException(string message):base(message)
    {}

}
