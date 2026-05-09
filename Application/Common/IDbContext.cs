using Microsoft.EntityFrameworkCore;

namespace Application.Common;

public interface IDbContext
{
    DbSet<T> Set<T>() where T : class;
    Task<int> SaveChangesAsync(CancellationToken ct = default);
}