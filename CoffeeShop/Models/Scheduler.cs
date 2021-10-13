using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CoffeeShop.Models
{
    public class Scheduler
    {
        [Key]
        public int EventId { get; set; }
        public string Subject { get; set; }

        public string Description { get; set; }

        public string Start { get; set; }
        public string End { get; set; }

        public string ThemeColor { get; set; }

        public string IsFullDay { get; set; }

    }
}