using STC.Shared.Utilities.Pagination.Abstracts;

namespace STC.Shared.Utilities.Response.Abstracts;

public interface IDataResponse<T> : IResponse
{
    public T? Data { get; set; }

    public IPaginationOut? Pagination { get; set; }
}