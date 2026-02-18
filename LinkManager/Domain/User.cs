using System.ComponentModel.DataAnnotations;

namespace LinkManager.Domain
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Username { get; set; } = "";
        public string Password { get; set; } = ""; // Gerçek hayatta şifrelenir ama şimdilik düz tutalım
        public string FullName { get; set; } = ""; // Ekranda "Hoşgeldin Ahmet" yazsın diye
    }
}