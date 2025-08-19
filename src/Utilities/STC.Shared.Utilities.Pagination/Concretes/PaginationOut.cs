using STC.Shared.Utilities.Pagination.Abstracts;

namespace STC.Shared.Utilities.Pagination.Concretes;

public record PaginationOut(long Page, long Count, long TotalCount) : IPaginationOut;