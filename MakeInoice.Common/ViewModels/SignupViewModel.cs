using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeInoice.Common.ViewModels
{
    /// <summary>
    /// Signup View Model
    /// </summary>
    /// <author>Alexey Bubley</author>
    /// <date>2021-10-21</date>
    public class SignupViewModel
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
