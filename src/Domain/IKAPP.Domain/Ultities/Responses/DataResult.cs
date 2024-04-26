using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Domain.Ultities.Responses;

public class DataResult<T> : Result,IDataResult<T>
{
    public T? Data { get; }

    public DataResult(T? data,HttpStatusCode statusCode,string message):base(statusCode,message)
    {
        Data= data; 
    }
    public DataResult(T? data, HttpStatusCode statusCode, List<string> messages) : base(statusCode, messages)
    {
        Data = data;
    }
    public static IResult DataResponse<T>(T? data,HttpStatusCode statusCode, string message)
    {
        return new DataResult<T>(data,statusCode, message);
    }
    public static IResult DataResponse<T>(T? data,HttpStatusCode statusCode, List<string> messages)
    {
        return new DataResult<T>(data,statusCode, messages);
    }

}
