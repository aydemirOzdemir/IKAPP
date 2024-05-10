using IKAPP.Domain.Entities.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Application.Features.AdvanceFeatures.AdvanceExceptions;

public class AdvanceMustNotBeNullException:BaseException
{
    public AdvanceMustNotBeNullException(string message):base(message)
    { }
}
