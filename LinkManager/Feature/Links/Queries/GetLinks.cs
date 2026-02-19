using LinkManager.Domain;
using LinkManager.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LinkManager.Feature.Links.Queries
{
    public record GetLinksQuery() : IRequest<List<LinkItem>>;

    public class GetLinksHandler : IRequestHandler<GetLinksQuery, List<LinkItem>>
    {
        private readonly AppDbContext _context;
        public GetLinksHandler(AppDbContext context) => _context = context;

        public async Task<List<LinkItem>> Handle(GetLinksQuery request, CancellationToken cancellationToken)
        {
            return await _context.Links.ToListAsync(cancellationToken);
        }
    }
}