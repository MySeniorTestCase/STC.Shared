namespace STC.Shared.Utilities.Pagination.Abstracts;

public interface IPaginationOut
{
    public long Page { get; init; }
    public long Count { get; init; }
    public long TotalCount { get; init; }
}