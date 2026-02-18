using LinkManager.Infrastructure;
using MediatR;

namespace LinkManager.Features.Links.Commands
{
    public class UpdateLinkCommand : IRequest
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public string Url { get; set; } = "";
        public string Category { get; set; } = "";
        public string Description { get; set; } = "";
        public string ColorClass { get; set; } = ""; // YENİ
    }

    public class UpdateLinkHandler : IRequestHandler<UpdateLinkCommand>
    {
        private readonly AppDbContext _context;
        public UpdateLinkHandler(AppDbContext context) => _context = context;

        public async Task Handle(UpdateLinkCommand request, CancellationToken cancellationToken)
        {
            var link = await _context.Links.FindAsync(request.Id);
            if (link != null)
            {
                link.Title = request.Title;
                link.Url = request.Url;
                link.Category = request.Category;
                link.Description = request.Description;
                link.ColorClass = request.ColorClass; // GÜNCELLE

                await _context.SaveChangesAsync(cancellationToken);
            }
        }
    }
}