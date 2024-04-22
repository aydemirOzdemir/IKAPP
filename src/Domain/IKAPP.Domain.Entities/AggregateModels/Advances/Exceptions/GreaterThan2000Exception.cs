using IKAPP.Domain.Entities.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Domain.Entities.AggregateModels.Advances.Exceptions;

public class GreaterThan2000Exception : BaseException
{
    public GreaterThan2000Exception(string message) : base(message) { }

}
