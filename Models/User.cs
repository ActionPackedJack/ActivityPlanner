using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Beltretake.Models;

namespace Beltretake.Models{
	public class User:BaseEntity{
        //public int id {get;set;}

        public string first {get;set;}
        public string last {get;set;}
        public string email {get;set;}
        public string password {get;set;}

        public List<Join> participating {get;set;}

        public User(){
            participating = new List<Join>();
        }

        public User(RegisterVM registerVM)
        {
            this.email= registerVM.email;
            this.first = registerVM.first;
            this.last = registerVM.last;
            this.password = registerVM.password;
        }
    }

/*
	Useful Annotations and Examples:

	[Required] - Makes a field required.
	[RegularExpression(@"[0-9]{0,}\.[0-9]{2}", ErrorMessage = "error Message")] - Put a REGEX string in here.
	[MinLength(100)] - Field must be at least 100 characters long.
	[MaxLength(1000)] - Field must be at most 1000 characters long.
	[Range(5,10)] - Field must be between 5 and 10 characters.
	[EmailAddress] - Field must contain an @ symbol, followed by a word and a period.
	[DataType(DataType.Password)] - Ensures that the field conforms to a specific DataType
*/
}

