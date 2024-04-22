using IKAPP.Domain.Entities.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Domain.SeedWorks.Base.Shared;

public class NamespaceCanNotBeEmptyException:BaseException
{
    public NamespaceCanNotBeEmptyException(string message):base(message)
    {}
}
