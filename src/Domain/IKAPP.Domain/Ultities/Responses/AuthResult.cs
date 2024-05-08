using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Domain.Ultities.Responses;

public class AuthResult<T> :Result, IAuthResult<T>
{
    public T Result { get; }



    public AuthResult(HttpStatusCode statusCode, string message,T result):base(statusCode,message)
    {
        Result = result;
    }

    public AuthResult(HttpStatusCode statusCode, List<string> messages, T result) : base(statusCode, messages)
    {
        Result = result;

    }
    public static IResult AuthResponse(HttpStatusCode statusCode, string message,T result)
    {
        return new AuthResult<T>(statusCode, message,result);
    }
    public static IResult AuthResponse(HttpStatusCode statusCode, List<string> messages, T result)
    {
        return new AuthResult<T>(statusCode, messages,result);

    }

}
