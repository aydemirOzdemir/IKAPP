using IKAPP.Domain.Entities.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Domain.SeedWorks.Base.Shared;

public class NamespaceMustBeAtLeast3CharactersLongException : BaseException 
{
    public NamespaceMustBeAtLeast3CharactersLongException(string message):base(message)
    { }
}

