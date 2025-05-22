namespace Starter.Api.Shared.Results;

public sealed record PaginatedResult<T>(
    IEnumerable<T> Items,
    long TotalCount,
    int Page,
    int PageSize)
{
    public int TotalPages
        => (int)Math.Ceiling((double)TotalCount / PageSize);

    public bool HasPreviousPage
        => Page > 1;

    public bool HasNextPage
        => Page < TotalPages;
}