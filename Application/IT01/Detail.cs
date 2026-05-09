using Application.Common;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.IT01;

public class Detail
{
    public class Request : IRequest<User?>
    {
        public int Id { get; set; }
    }

    public class Handler(IDbContext context) : IRequestHandler<Request, User?>
    {
        public async Task<User?> Handle(Request request, CancellationToken ct)
            => await context.Set<User>()
                .Where(u => u.Id == request.Id)
                .FirstOrDefaultAsync(ct);
    }
}