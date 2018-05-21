using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Beltretake.Models
{
    public class RegisterVM
    {
        [Required]
        [MinLength(1)]
        [EmailAddress]
        public string email {get;set;}
        [Required]
        [MinLength(1)]
        public string first {get;set;}
        [Required]
        [MinLength(1)]
        public string last {get;set;}
        [Required]
        [MinLength(8)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$", ErrorMessage="Password not complicated enough.")]
        [DataType(DataType.Password)]
        public string password {get;set;}
        [Required]
        [MinLength(8)]
        [DataType(DataType.Password)]
        [Compare("password")]
        public string confirm {get;set;}
    }
}
