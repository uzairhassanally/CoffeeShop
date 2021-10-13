using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CoffeeShop.Models
{
    public partial class Category
    {
        public int CategoryId { get; set; }

        [Display(Name = "Category Name: ")]
        public string Name { get; set; }

        [Display(Name = "Category Description: ")]
        public string Description { get; set; }

       
        public List<Item> Items { get; set; }

    }
}