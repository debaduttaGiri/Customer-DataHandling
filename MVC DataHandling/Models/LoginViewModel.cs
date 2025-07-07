using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVC_DataHandling.Models
{
    public class LoginViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DisplayName("Remember Me")]
        public bool RememberMe { get; set; }

        public string ReturnUrl { get; set; } = "";

    }
}
