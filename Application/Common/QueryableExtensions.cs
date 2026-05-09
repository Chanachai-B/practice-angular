using Microsoft.EntityFrameworkCore;

namespace Application.Common;

public static class QueryableExtensions
{
    public static async Task<PaginatedResult<T>> ToPaginatedAsync<T>(
        this IQueryable<T> query, int page, int size, CancellationToken ct = default)
    {
        var total = await query.CountAsync(ct);
        var items = await query.Skip((page - 1) * size).Take(size).ToListAsync(ct);
        return new PaginatedResult<T> { Total = total, Page = page, Size = size, Items = items };
    }

    public static async Task<PaginatedResult<TResult>> ToPaginatedAsync<T, TResult>(
        this IQueryable<T> query, int page, int size, Func<T, TResult> mapper, CancellationToken ct = default)
    {
        var total = await query.CountAsync(ct);
        var items = (await query.Skip((page - 1) * size).Take(size).ToListAsync(ct))
            .Select(mapper).ToList();
        return new PaginatedResult<TResult> { Total = total, Page = page, Size = size, Items = items };
    }
}