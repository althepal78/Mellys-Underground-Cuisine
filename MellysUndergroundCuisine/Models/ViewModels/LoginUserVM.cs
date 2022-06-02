using System.ComponentModel.DataAnnotations;

namespace MellysUndergroundCuisine.Models.ViewModels
{
    public class LoginUserVM
    {
        [Required]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
