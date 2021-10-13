using CoffeeShop.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace CoffeeShop.Models
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int ItemId { get; set; }

       
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        
        public string Status { get; set; }

       
      

        public virtual Item Item { get; set; }
        public virtual Order Order { get; set; }

        
       


    }
}