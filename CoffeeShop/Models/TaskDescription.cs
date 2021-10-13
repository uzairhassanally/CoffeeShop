using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace CoffeeShop.Models
{
    public class TaskDescription
    {
        [Key]
        public int NameId { get; set; }

        [Display(Name = "Task Description: ")]
        public string TaskName { get; set; }




    }
}