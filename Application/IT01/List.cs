using Application.Common;
using Domain.Entities;
using MediatR;

namespace Application.IT01;

public class List
{
    public class Request : IRequest<PaginatedResult<UserDto>>
    {
        public int Page { get; set; } = 1;
        public int Size { get; set; } = 10;
    }

    public class UserDto
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public DateOnly Dob { get; set; }
        public int Age { get; set; }
    }

    public class Handler(IDbContext context) : IRequestHandler<Request, PaginatedResult<UserDto>>
    {
        public async Task<PaginatedResult<UserDto>> Handle(Request request, CancellationToken ct)
            => await context.Set<User>()
                .ToPaginatedAsync(request.Page, request.Size, u => new UserDto
                {
                    Id = u.Id,
                    FullName = u.Name + " " + u.Lastname,
                    Address = u.Address,
                    Dob = u.Dob,
                    Age = u.Age
                }, ct);
    }
}