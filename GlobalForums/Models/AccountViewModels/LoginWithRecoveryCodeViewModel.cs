using System.ComponentModel.DataAnnotations;

namespace GlobalForums.Models.AccountViewModels
{
    public class LoginWithRecoveryCodeViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Recovery code")]
        public string RecoveryCode { get; set; }
    }
}
