namespace STC.Shared.Utilities.Pagination.Abstracts;

public interface IPaginationArguments
{
    public long Page { get; init; }
    public long? ItemCountInThePage { get; init; }
    public ISortDefinition[] Sorts { get; init; }
}