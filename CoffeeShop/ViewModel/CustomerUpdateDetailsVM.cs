using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CoffeeShop.ViewModel
{

    [NotMapped]
    public class CustomerUpdateDetailsVM
    {


        [Required(AllowEmptyStrings = false, ErrorMessage = " Current Password  is Required")]
        [Display(Name = "Current Password: ")]
        [DataType(DataType.Password)]
        public string CurrentPassword { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = " New Password  is Required")]
        [Display(Name = "New Password: ")]
        [DataType(DataType.Password)]
        public string NewPassWord { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "First Name  is Required")]
        [Display(Name = "Current First Name: ")]
        public string CurrentFirstName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "First Name  is Required")]
        [Display(Name = "Update First Name: ")]
        public string UpdateFirstName { get; set; }



        [Required(AllowEmptyStrings = false, ErrorMessage = "First Name  is Required")]
        [Display(Name = "Current Last Name: ")]
        public string CurrentLastName { get; set; }


        [Required(AllowEmptyStrings = false, ErrorMessage = "Last Name  is Required")]
        [Display(Name = " Update Last Name: ")]
        public string UpdateLastName { get; set; }


        //[Required(AllowEmptyStrings = false, ErrorMessage = "User Name  is Required")]
        //[Display(Name = "Current User Name: ")]
        //public string CurrentUserName { get; set; }


        //[Required(AllowEmptyStrings = false, ErrorMessage = "User Name  is Required")]
        //[Display(Name = " Update User Name: ")]
        //public string UpdateUserName { get; set; }


        [Required(AllowEmptyStrings = false, ErrorMessage = "Email  is Required")]
        [Display(Name = "Current Email: ")]
        public string CurrentEmail { get; set; }


        [Required(AllowEmptyStrings = false, ErrorMessage = "Email is Required")]
        [Display(Name = " Update Email: ")]
        public string UpdateEmail { get; set; }


        [Required(AllowEmptyStrings = false, ErrorMessage = "Month is Required")]
        [Display(Name = " current Month: ")]
        public string CurrentMonth{ get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Month is Required")]
        [Display(Name = " Update Month: ")]
        public string UpdateMonth { get; set; }


        [Required(AllowEmptyStrings = false, ErrorMessage = "Year is Required")]
        [Display(Name = " current Year: ")]
        public int CurrentYear { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Year is Required")]
        [Display(Name = " Update Year: ")]
        public int UpdateYear { get; set; }


        [Required(AllowEmptyStrings = false, ErrorMessage = "Date is Required")]
        [Display(Name = " current Date: ")]
        public string CurrentDate { get; set; }


        [Required(AllowEmptyStrings = false, ErrorMessage = "Date is Required")]
        [Display(Name = " Update Date: ")]
        public string UpdateDate { get; set; }


    }









}