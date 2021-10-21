using System.ComponentModel.DataAnnotations;

namespace MakeInoice.Common.ViewModels
{
    /// <summary>
    /// Signin View Model
    /// </summary>
    /// <author>Alexey Bubley</author>
    /// <date>2021-10-21</date>
    public class SigninViewModel
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
