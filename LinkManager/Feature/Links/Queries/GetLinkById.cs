using LinkManager.Domain;
using LinkManager.Infrastructure;
using MediatR;

namespace LinkManager.Features.Links.Queries
{
    // 1. SORGU: Bana şu ID'li linki getir.
    public record GetLinkByIdQuery(int Id) : IRequest<LinkItem>;

    // 2. İŞLEYİCİ
    public class GetLinkByIdHandler : IRequestHandler<GetLinkByIdQuery, LinkItem>
    {
        private readonly AppDbContext _context;

        public GetLinkByIdHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<LinkItem> Handle(GetLinkByIdQuery request, CancellationToken cancellationToken)
        {
            // Veritabanından o ID'yi bul ve geri gönder
            return await _context.Links.FindAsync(request.Id);
        }
    }
}