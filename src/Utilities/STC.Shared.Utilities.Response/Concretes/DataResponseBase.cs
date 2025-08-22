using System.Net;
using STC.Shared.Utilities.Pagination.Abstracts;
using STC.Shared.Utilities.Response.Abstracts;

namespace STC.Shared.Utilities.Response.Concretes;

public sealed class DataResponseBase<T> : ResponseBase, IDataResponse<T>
{
    public DataResponseBase()
    {
    }

    public DataResponseBase(string message, HttpStatusCode statusCode, ResponseMessageTypes messageType, bool isSuccess,
        T? data, IPaginationOut? pagination = null) : base(message, statusCode, messageType: messageType,
        isSuccess, validationExceptions: null)
    {
        Data = data;
        Pagination = pagination;
    }

    public DataResponseBase(IResponse response, T? data, IPaginationOut? pagination = null) : base(
        message: response.Message, statusCode: response.StatusCode,
        messageType: response.MessageType,
        isSuccess: response.IsSuccess, validationExceptions: null)
    {
        Data = data;
        Pagination = pagination;
    }

    public T? Data { get; set; } = default;
    public IPaginationOut? Pagination { get; set; }
}