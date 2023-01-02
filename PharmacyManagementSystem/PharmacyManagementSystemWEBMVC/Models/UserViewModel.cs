using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PharmacyManagementSystemWEBMVC.Models
{
    public class UserViewModel
    {
        public int UserID { get; set; }
        [Required(ErrorMessage = "User name is required")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Enter the valid Email Address")]
        public string EmailID { get; set; }
        [Required(ErrorMessage = "Password is required")]

       
        [StringLength(100, ErrorMessage = "The{0} must be at least{2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
        [Required(ErrorMessage = "ConfirmPassword is required")]
        [Compare(otherProperty: "Password", ErrorMessage = "Password and Confirm Password must be same")]
        public string ConfirmPassword { get; set; }
    }
}