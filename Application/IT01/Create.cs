using Application.Common;
using Domain.Entities;
using MediatR;

namespace Application.IT01;

public class Create
{
    public class Request : IRequest<int>
    {
        public string Name { get; set; } = string.Empty;
        public string Lastname { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public DateOnly Dob { get; set; }
    }

    public class Handler(IDbContext context) : IRequestHandler<Request, int>
    {
        public async Task<int> Handle(Request request, CancellationToken ct)
        {
            var user = new User
            {
                Name = request.Name,
                Lastname = request.Lastname,
                Address = request.Address,
                Dob = request.Dob
            };

            await context.Set<User>().AddAsync(user, ct);
            await context.SaveChangesAsync(ct);

            return user.Id;
        }
    }
}