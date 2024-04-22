using System.ComponentModel.DataAnnotations;

namespace CarRent.ViewModels
{
    //a mezok kitoltese kotelezo
    public class LoginVM
    {

        [Required(ErrorMessage = "Username is required.")]
        public string? Username { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

    }
}
