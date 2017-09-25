using System.ComponentModel.DataAnnotations;

namespace Vidly.ViewModels.Account
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Driving License")]
        public string DrivingLicense { get; set; }
        [Required]
        [Display(Name = "Phone Number")]
        [StringLength(55)]
        public string Phone { get; set; }
    }

}