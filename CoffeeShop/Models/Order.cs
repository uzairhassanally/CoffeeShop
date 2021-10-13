using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace CoffeeShop.Models
{
    [Bind(Exclude = "OrderId")]
    public partial class Order
    {
        [ScaffoldColumn(false)]
        public int OrderId { get; set; }
        [ScaffoldColumn(false)]
        public System.DateTime OrderDate { get; set; }



        [ScaffoldColumn(false)]
        public string Username { get; set; }


        [ScaffoldColumn(false)]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}",
            ErrorMessage = "Email is is not valid.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [ScaffoldColumn(false)]
        public string Status { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "Give your order a name: ")]
        public string Ordername { get; set; }



        [ScaffoldColumn(false)]
        public decimal Total { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }

        public void OrderAccepted()
        {
            MailMessage mc = new MailMessage(System.Configuration.ConfigurationManager.AppSettings["Email"].ToString(), Email);
            mc.Subject = "Your Order has been Accepted" ;
            mc.Body = "Your Order Name is " + Username+ " " + "and being prepared you estimated time is 15 mins";
            mc.IsBodyHtml = false;
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.Timeout = 1000000;
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            NetworkCredential nc = new NetworkCredential(System.Configuration.ConfigurationManager.AppSettings["Email"].ToString(), System.Configuration.ConfigurationManager.AppSettings["Password"].ToString());
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = nc;
            smtp.Send(mc);

        }
        public void OrderReady()
        {
            MailMessage mc = new MailMessage(System.Configuration.ConfigurationManager.AppSettings["Email"].ToString(), Email);
            mc.Subject = "Hooray";
            mc.Body = "Your Order"+ " " + "is Ready." + "See you Soon...";
            mc.IsBodyHtml = false;
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.Timeout = 1000000;
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            NetworkCredential nc = new NetworkCredential(System.Configuration.ConfigurationManager.AppSettings["Email"].ToString(), System.Configuration.ConfigurationManager.AppSettings["Password"].ToString());
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = nc;
            smtp.Send(mc);
        }

        public void PickupConfirmed()
        {
            MailMessage mc = new MailMessage(System.Configuration.ConfigurationManager.AppSettings["Email"].ToString(), Email);
            mc.Subject = "Pick Up Confirmed ";
            mc.Body = "Thank you for your Order " + Username + " Enjoy your Meal. ";
            mc.IsBodyHtml = false;
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.Timeout = 1000000;
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            NetworkCredential nc = new NetworkCredential(System.Configuration.ConfigurationManager.AppSettings["Email"].ToString(), System.Configuration.ConfigurationManager.AppSettings["Password"].ToString());
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = nc;
            smtp.Send(mc);
        }
    }
}