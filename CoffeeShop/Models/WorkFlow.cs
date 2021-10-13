using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CoffeeShop.Models
{
    public class WorkFlow
    {
        public int WorkFlowID { get; set; }

        public int NameId { get; set; }

        public string DueDate { get; set; }


        public string Status { get; set; }

        [Display(Name = " Username: ")]
        public string UserName { get; set; }

        public virtual EmployeeRegister EmployeeRegister { get; set; }

        public virtual TaskDescription TaskDescription { get; set; }
    }
}