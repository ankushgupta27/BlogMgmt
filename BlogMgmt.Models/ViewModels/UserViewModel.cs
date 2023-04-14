using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

// using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
namespace BlogMgmt.Models.ViewModels;
public class UserViewModel
{
    [Key]
    public int Id { get; set; }
    [Required(ErrorMessage = "Full Name is required")]
    public string FullName { get; set; }

    [EmailAddress]
    [Required(ErrorMessage = "Email is required")]
    [Display(Name = "Email")]
    [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,6}", ErrorMessage = "Incorrect Email Format")]
    [Remote(action: "VerifyEmail", controller: "User")]
    public string Email { get; set; }
    [RegularExpression("^((?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])|(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[^a-zA-Z0-9])|(?=.*?[A-Z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])|(?=.*?[a-z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])).{8,}$", ErrorMessage = "Passwords must be at least 8 characters and contain at 3 of 4 of the following: upper case (A-Z), lower case (a-z), number (0-9) and special character (e.g. !@#$%^&*)")]
    [Required(ErrorMessage = "Required")]
    public string? Password { get; set; }
    [Required(ErrorMessage = "Rrequired")]
    [DataType(DataType.Password)]
    [Compare("Password")]
    public string? ConfirmPassword { get; set; }
    [Required(ErrorMessage = "City  is required")]
    public int CityId { get; set; }
    [Required(ErrorMessage = "State is required")]
    public int StateId { get; set; }
    [Required(ErrorMessage = "Country is required")]
    public int CountryId { get; set; }
    [Required]
    [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Please Enter Valid Mobile Number.")]
    public long MobileNo { get; set; }
    public bool IsActive { get; set; }
    public bool? IsEmailVerified { get; set; }
    public int RoleId { get; set; }
    [Range(1, 120, ErrorMessage = "incorrect")]
    public int CreatedBy { get; set; }
    public DateTime CreatedOn { get; set; }
    public long? UpdatedBy { get; set; }
    public DateTime? UpdatedOn { get; set; }




    // public string ProfilePic { get; set; }

    // [Required(ErrorMessage = "Confirm Password is required")]
    // [DataType(DataType.Password)]
    // [Compare("Password")]
    // public string ConfirmPassword { get; set; }

    // public virtual ICollection<Cart> Carts { get; } = new List<Cart>();
    // public virtual ICollection<OrderReceived> OrderReceiveds { get; } = new List<OrderReceived>();
    // public virtual Role Role { get; set; }
}

// public enum country
// { India=1,China=2,Pakistan=3,USA=4
//  }