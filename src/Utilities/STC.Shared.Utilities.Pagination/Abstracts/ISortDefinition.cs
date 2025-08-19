using STC.Shared.Utilities.Pagination.Concretes;

namespace STC.Shared.Utilities.Pagination.Abstracts;

public interface ISortDefinition
{
    public OrderBy OrderBy { get; init; }
    public string Field { get; init; }
}