
using System.Collections.Generic;
using System.Linq;
using System;
using System.ComponentModel.DataAnnotations;
using Beltretake.Models;

namespace Beltretake.Models
{
    public class Activity: BaseEntity
    {
        public int creatorid {get;set;}
        public User creator {get;set;}
        public string name {get;set;}
        public string description {get;set;}
        public DateTime start {get;set;}
        public TimeSpan duration {get;set;}
        public List<Join> participating {get;set;}

        public Activity(){
            participating = new List<Join>();
        }

    }
}