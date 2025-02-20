using System.ComponentModel.DataAnnotations;

namespace RAD302Week3Lab12025WebAPIS00237686.ViewModel
{
    public class RegisterViewModel
    {
        [Required]
        public string Fname { get; set; }

        [Required]
        public string Sname { get; set; }

        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
