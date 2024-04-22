using IKAPP.Domain.Entities.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Domain.Entities.AggregateModels.Expenses.Exceptions;

public class DocumantationCanNotBeEmptyException:BaseException
{
    public DocumantationCanNotBeEmptyException(string message):base(message)
    {}
}
