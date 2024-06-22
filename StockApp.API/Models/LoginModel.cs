using System.ComponentModel.DataAnnotations;

namespace StockApp.API.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid format email")]
        public string? Email { get; set; }

        [Required (ErrorMessage ="Password is required")]
        [StringLength(20, ErrorMessage ="The {0} must be at least {2} ant at max {1} characters long.", MinimumLength = 10)]
        public string Password { get; set; }
    }
}
