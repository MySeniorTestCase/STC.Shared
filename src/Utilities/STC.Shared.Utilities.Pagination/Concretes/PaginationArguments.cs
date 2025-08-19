using STC.Shared.Utilities.Pagination.Abstracts;

namespace STC.Shared.Utilities.Pagination.Concretes;

public record PaginationArguments(long Page, long? ItemCountInThePage, ISortDefinition[] Sorts) : IPaginationArguments;