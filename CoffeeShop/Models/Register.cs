using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace CoffeeShop.Models
{
    public class EmployeeRegister
    {

        [Key]
        [Display(Name = " Username: ")]
        public string UserName { get; set; }

        [Display(Name = "First Name: ")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name: ")]
        public string LastName { get; set; }


        [Display(Name = "Role: ")]
        public string Role { get; set; }

        [Display(Name = "Employee ID: ")]
        public string EmployeeId { get; set; }

        [Display(Name = "Salary: ")]
        public string Amount { get; set; }


        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email Address: ")]
        public string Email { get; set; }


        [DataType(DataType.Password)]
        [Display(Name = "Password: ")]
        public string Password { get; set; }


       
   


    }





    public class CustomerRegister
    {
        [Key]


        public string UserName { get; set; }


        public string FirstName { get; set; }


        public string Date { get; set; }
        public string Month { get; set; }


        public int Year { get; set; }

        public string LastName { get; set; }


        public string Email { get; set; }

        public string To { get; set; }

        public string Password { get; set; }

       

        public void SendMail()
        {
            MailMessage mc = new MailMessage(System.Configuration.ConfigurationManager.AppSettings["Email"].ToString(), To);
            mc.Subject = "Happy BirthDay";
            mc.Body = "Wish You Well" + " " + UserName + " " + "You Have recieved a Free Birthday Coffee At Any of Our Store. You Will be Required to Bring Your ID";
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



    public class AdminRegister
    {
        [Key]

        public string Email { get; set; }


        public string FirstName { get; set; }


        public string LastName { get; set; }


        public string UserName { get; set; }



        public string Password { get; set; }

    }


    public class Login
    {
        [Key]


        public string UserName { get; set; }



        public string Password { get; set; }


    }


}