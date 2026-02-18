using LinkManager.Domain;
using LinkManager.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LinkManager.Features.Links.Commands
{
    // 1. KOMUT: "Şu ID'li linki sil" diyoruz.
    public record DeleteLinkCommand(int Id) : IRequest;

    // 2. İŞLEYİCİ: Veritabanından bulup siliyor.
    public class DeleteLinkHandler : IRequestHandler<DeleteLinkCommand>
    {
        private readonly AppDbContext _context;

        public DeleteLinkHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task Handle(DeleteLinkCommand request, CancellationToken cancellationToken)
        {
            // Silinecek linki bul
            var link = await _context.Links.FindAsync(request.Id);

            if (link != null)
            {
                // Bulduysan sil ve kaydet
                _context.Links.Remove(link);
                await _context.SaveChangesAsync(cancellationToken);
            }
        }
    }
}