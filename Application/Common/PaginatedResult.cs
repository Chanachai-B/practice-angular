namespace Application.Common;

public class PaginatedResult<T>
{
    public int Total { get; set; }
    public int Page { get; set; }
    public int Size { get; set; }
    public IEnumerable<T> Items { get; set; } = [];
}