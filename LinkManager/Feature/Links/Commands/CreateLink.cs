using LinkManager.Domain;
using LinkManager.Infrastructure;
using MediatR;

namespace LinkManager.Feature.Links.Commands
{
    public class CreateLinkCommand : IRequest<int>
    {
        public string Title { get; set; } = "";
        public string Url { get; set; } = "";
        public string Category { get; set; } = "";
        public string Description { get; set; } = "";
        public string ColorClass { get; set; } = "bg-white text-dark";
        public string IconClass { get; set; } = "fa-solid fa-link"; // Eklendi
    }

    public class CreateLinkHandler : IRequestHandler<CreateLinkCommand, int>
    {
        private readonly AppDbContext _context;
        public CreateLinkHandler(AppDbContext context) => _context = context;

        public async Task<int> Handle(CreateLinkCommand request, CancellationToken cancellationToken)
        {
            var newLink = new LinkItem
            {
                Title = request.Title,
                Url = request.Url,
                Category = request.Category,
                Description = request.Description,
                ColorClass = request.ColorClass,
                IconClass = request.IconClass, // Eklendi
                IsActive = true
            };

            _context.Links.Add(newLink);
            await _context.SaveChangesAsync(cancellationToken);
            return newLink.Id;
        }
    }
}