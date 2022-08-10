using System.ComponentModel.DataAnnotations;

namespace GlobalForums.Models.AccountViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
