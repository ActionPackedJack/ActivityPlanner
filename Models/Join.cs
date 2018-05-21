using System.Collections.Generic;
using Beltretake.Models;
using System.Linq;

namespace Beltretake.Models{


    public class Join{
        public int joinid {get;set;}
        public int activityid {get;set;}
        public int userid {get;set;}
        public Activity activity {get;set;}
        public User user {get;set;}
    }
}