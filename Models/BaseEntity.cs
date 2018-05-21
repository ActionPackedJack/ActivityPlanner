using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Beltretake.Models
{
    public abstract class BaseEntity
    {
        [Key]
        public int id{get;set;}
    }
}