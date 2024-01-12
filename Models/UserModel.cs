
using System.ComponentModel.DataAnnotations;
namespace LoginPage.Models
{

    public class UserModel
    {
       
        [Required(ErrorMessage = "Username is required.")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Username must contain only numbers.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d).{8,}$",
            ErrorMessage = "Password must be at least 8 characters long and contain at least one uppercase letter, one lowercase letter, and one digit.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }

}
