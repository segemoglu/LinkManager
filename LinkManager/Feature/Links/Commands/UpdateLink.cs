using LinkManager.Infrastructure;
using MediatR;

namespace LinkManager.Feature.Links.Commands
{
    public class UpdateLinkCommand : IRequest
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public string Url { get; set; } = "";
        public string Category { get; set; } = "";
        public string Description { get; set; } = "";
        public string ColorClass { get; set; } = "";
        public string IconClass { get; set; } = "fa-solid fa-link"; // Eklendi
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
                link.ColorClass = request.ColorClass;
                link.IconClass = request.IconClass; // Eklendi

                await _context.SaveChangesAsync(cancellationToken);
            }
        }
    }
}