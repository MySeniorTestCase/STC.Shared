using System.Net;
using STC.Shared.Utilities.Response.Concretes;

namespace STC.Shared.Utilities.Response.Abstracts;

public interface IResponse
{
    public string Message { get; set; }
    public HttpStatusCode StatusCode { get; set; }
    public ResponseMessageTypes MessageType { get; set; }
    public bool IsSuccess { get; set; }
    public List<KeyValuePair<string, string>> ValidationExceptions { get; set; }
}