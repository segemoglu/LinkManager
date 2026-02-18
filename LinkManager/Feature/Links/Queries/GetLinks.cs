using LinkManager.Domain;
using LinkManager.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LinkManager.Features.Links.Queries
{
    // 1. SORGU (Query): Bizden ne isteniyor? "Tüm linkleri getir".
    // Cevap olarak List<LinkItem> dönecek.
    public record GetLinksQuery : IRequest<List<LinkItem>>;

    // 2. İŞLEYİCİ (Handler): Veritabanına gidip alıp gelen eleman.
    public class GetLinksHandler : IRequestHandler<GetLinksQuery, List<LinkItem>>
    {
        private readonly AppDbContext _context;

        public GetLinksHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<LinkItem>> Handle(GetLinksQuery request, CancellationToken cancellationToken)
        {
            // Veritabanındaki tüm linkleri listeye çevir ve gönder
            // AsNoTracking() -> Sadece okuma yapacağımız için hızlandırır.
            return await _context.Links.AsNoTracking().ToListAsync(cancellationToken);
        }
    }
}