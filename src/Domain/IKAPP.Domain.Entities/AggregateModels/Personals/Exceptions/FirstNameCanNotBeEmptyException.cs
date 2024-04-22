using IKAPP.Domain.Entities.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Domain.Entities.AggregateModels.Personals.Exceptions;

public class FirstNameCanNotBeEmptyException:BaseException
{
    public FirstNameCanNotBeEmptyException(string message):base(message)
    {}
}
