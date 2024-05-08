using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Domain.Ultities.Responses;

public interface IAuthResult<T>:IResult
{ 
    T Result { get; }
}
