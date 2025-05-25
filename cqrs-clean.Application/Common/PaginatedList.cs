using Microsoft.EntityFrameworkCore;

namespace cqrs_clean.Application.Common;

public class PaginatedList<T>
{
    public int PageIndex { get; private set; }
    public int TotalPages { get; private set; }
    public int CountData { get; private set; }
    public bool HasPreviousPage => PageIndex > 1;
    public bool HasNextPage => PageIndex < TotalPages;
    public List<T> Data { get; private set; }

    public PaginatedList(List<T> data, int pageIndex, int totalPages, int countData)
    {
        PageIndex = pageIndex;
        CountData = countData;
        Data = data;
        TotalPages = totalPages;
    }

    public static async Task<PaginatedList<T>> CreateAsync(IQueryable<T> source, int pageIndex = 1, int pageSize = 10)
    {
        pageIndex = Math.Max(pageIndex, 1);
        pageSize = Math.Max(pageSize, 1);

        var count = await source.CountAsync();
        var items = await source.Skip((pageIndex - 1) * pageSize)
                                .Take(pageSize)
                                .ToListAsync();
        var totalPages = (int)Math.Ceiling(count / (double)pageSize);

        return new PaginatedList<T>(items, pageIndex, totalPages, count);
    }

    public static async Task<PaginatedList<T>> CreateAsync(
    IQueryable<T> source,
    int pageIndex = 1,
    int pageSize = 10,
    CancellationToken cancellationToken = default)
    {
        pageIndex = Math.Max(pageIndex, 1);
        pageSize = Math.Max(pageSize, 1);

        var count = await source.CountAsync(cancellationToken);
        var items = await source.Skip((pageIndex - 1) * pageSize)
                                .Take(pageSize)
                                .ToListAsync(cancellationToken);
        var totalPages = (int)Math.Ceiling(count / (double)pageSize);

        return new PaginatedList<T>(items, pageIndex, totalPages, count);
    }

    public static PaginatedList<T> Create(List<T> source, int pageIndex = 1, int pageSize = 10)
    {
        pageIndex = Math.Max(pageIndex, 1);
        pageSize = Math.Max(pageSize, 1);

        var count = source.Count;
        var items = source.Skip((pageIndex - 1) * pageSize)
                          .Take(pageSize)
                          .ToList();
        var totalPages = (int)Math.Ceiling(count / (double)pageSize);

        return new PaginatedList<T>(items, pageIndex, totalPages, count);
    }
}