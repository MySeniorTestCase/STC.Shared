using System.Net;
using STC.Shared.Utilities.Response.Abstracts;

namespace STC.Shared.Utilities.Response.Concretes;

public class ResponseBase : IResponse
{
    protected ResponseBase()
    {
    }

    public ResponseBase(string message, HttpStatusCode statusCode, ResponseMessageTypes messageType, bool isSuccess,
        List<KeyValuePair<string, string>>? validationExceptions)
    {
        Message = message;
        StatusCode = statusCode;
        MessageType = messageType;
        IsSuccess = isSuccess;
        ValidationExceptions = validationExceptions ?? new List<KeyValuePair<string, string>>();
    }

    public string Message { get; set; } = null!;
    public HttpStatusCode StatusCode { get; set; }
    public ResponseMessageTypes MessageType { get; set; }
    public bool IsSuccess { get; set; }
    public List<KeyValuePair<string, string>> ValidationExceptions { get; set; } = [];
}