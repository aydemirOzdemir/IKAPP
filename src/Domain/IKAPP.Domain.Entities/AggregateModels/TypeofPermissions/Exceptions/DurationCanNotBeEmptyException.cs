using IKAPP.Domain.Entities.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Domain.Entities.AggregateModels.TypeofPermissions.Exceptions;

public class DurationCanNotBeEmptyException:BaseException
{
    public DurationCanNotBeEmptyException(string message):base(message)
    {}
}
