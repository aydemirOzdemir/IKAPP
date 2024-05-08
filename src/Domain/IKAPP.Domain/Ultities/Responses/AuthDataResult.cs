using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Domain.Ultities.Responses;

public class AuthDataResult<TData, TResult> : DataResult<TData>, IAuthDataResult<TData, TResult>
{


    public TResult Result { get; }


    public AuthDataResult(TData? data, HttpStatusCode statusCode, string message,TResult result) : base(data,statusCode, message)
    {
       Result=result;
    }
    public AuthDataResult(TData? data, HttpStatusCode statusCode, List<string> messages,TResult result) : base(data,statusCode, messages)
    {
        Result = result;
    }

    public static IResult AuthDataResponse(HttpStatusCode statusCode, string message, TData data,TResult result)
    {
        return new AuthDataResult<TData,TResult>(data,statusCode, message, result);
    }
    public static IResult AuthDataResponse(HttpStatusCode statusCode, List<string> messages, TData data,TResult result)
    {
        return new AuthDataResult<TData,TResult>(data,statusCode, messages, result);
    }


}
