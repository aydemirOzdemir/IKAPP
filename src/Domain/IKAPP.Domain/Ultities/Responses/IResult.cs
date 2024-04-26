using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Domain.Ultities.Responses;

public interface IResult
{
    HttpStatusCode StatusCode { get; }
    List<string> Message { get; }
}
