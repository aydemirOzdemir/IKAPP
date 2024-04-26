using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Domain.Ultities.Responses;

public class Result : IResult
{
    public HttpStatusCode StatusCode { get; }

    public List<string> Message { get; }
 

    public Result(HttpStatusCode statusCode,string message) 
    {
        Message = new();
        StatusCode = statusCode;
        Message.Add(message);   
    }

    public Result(HttpStatusCode statusCode, List<string> messages)
    {
        Message = new();
        Message.AddRange(messages);
        StatusCode = statusCode;
        
    }
    public static IResult Response(HttpStatusCode statusCode, string message)
    {
        return new Result(statusCode,message);
    }
    public static IResult Response(HttpStatusCode statusCode, List<string> messages)
    {
        return new Result(statusCode, messages);
       
    }
}
