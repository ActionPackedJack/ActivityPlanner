using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Beltretake.Models
{
    public class LoginVM
    {
        [Required]
        [MinLength(1)]
        [EmailAddress]
        public string email {get;set;}
        [Required]
        [MinLength(8)]
        [DataType(DataType.Password)]
        public string password {get;set;}
    }
}
