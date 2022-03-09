using System.ComponentModel.DataAnnotations;

namespace Formula1.MVC.Models
{
    public class LoginViewModel
    {
        [Required]
        public string? Email { get; set; }

        [Required]
        public string? Senha { get; set; }
    }
}