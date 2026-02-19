using LinkManager.Domain;
using LinkManager.Infrastructure;
using MediatR;

namespace LinkManager.Feature.Links.Queries
{
    public record GetLinkByIdQuery(int Id) : IRequest<LinkItem>;

    public class GetLinkByIdHandler : IRequestHandler<GetLinkByIdQuery, LinkItem>
    {
        private readonly AppDbContext _context;
        public GetLinkByIdHandler(AppDbContext context) => _context = context;

        public async Task<LinkItem> Handle(GetLinkByIdQuery request, CancellationToken cancellationToken)
        {
            return await _context.Links.FindAsync(request.Id);
        }
    }
}