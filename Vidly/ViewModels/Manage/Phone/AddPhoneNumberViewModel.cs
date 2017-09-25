using System.ComponentModel.DataAnnotations;

namespace Vidly.ViewModels.Manage.Phone
{
    public class AddPhoneNumberViewModel
    {
        [Required]
        [Phone]
        [Display(Name = "Phone Number")]
        public string Number { get; set; }
    }
}