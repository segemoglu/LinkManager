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

        // YENİ ÖZELLİK: Kart Rengi (Varsayılan Beyaz)
        public string ColorClass { get; set; } = "bg-white text-dark";
    }
}