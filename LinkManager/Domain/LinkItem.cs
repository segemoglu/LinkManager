using System.ComponentModel.DataAnnotations;

namespace LinkManager.Domain
{
    public class LinkItem
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Category { get; set; } = "Genel";
        public bool IsActive { get; set; } = true;
        public string ColorClass { get; set; } = "bg-white text-dark";

        // YENİ EKLENEN KISIM
        public string IconClass { get; set; } = "fa-solid fa-link";
    }
}