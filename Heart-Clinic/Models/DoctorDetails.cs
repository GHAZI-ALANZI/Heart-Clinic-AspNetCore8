﻿using System.ComponentModel.DataAnnotations;

namespace Heart_Clinic.Models
{
    public class DoctorDetails
    {
        [Required]
        [Key]

        public int DoctorID { get; set; }

        [Required(ErrorMessage = "First Name is required.")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "special characters are not allowed.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required.")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "special characters are not allowed.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Gender is required.")]
        [Display(Name = "Gender")]
        public string Sex { get; set; }

        [Required(ErrorMessage = "Age is required.")]
        [Range(1, 120, ErrorMessage = "Age must be between 1-120 in years.")]
        public int Age { get; set; }


        [Display(Name = "Date of Birth")]
        [Required(ErrorMessage = "Birth Date is required.")]
        [RegularExpression(@"(((0|1)[0-9]|2[0-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$", ErrorMessage = "Enter dd/mm/yyyy format please.")]
        public string BirthDate { get; set; }


        [Display(Name = "Specialization")]
        public ASpecializationRequired SpecializationRequired { get; set; }
        public enum ASpecializationRequired
        {
            General, Gynaecologist, Pediatrics, Orthopedics, Ophthalmology
        }

        [Range(1, 50, ErrorMessage = "Enter experience between 1 and 50 in years.")]
        [Required(ErrorMessage = "Experience is required.")]
        public int Experiance { get; set; }



        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Oops ! Invalid Email.")]
        [Required(ErrorMessage = "Email-ID is required.")]
        [Display(Name = "Email-ID")]

        public String DocEmail { get; set; }


        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Mobile No")]
        [Required(ErrorMessage = "Phone Number Required!")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$",
                   ErrorMessage = "Oops ! Enter a valid number please")]
        public long ContactNo { get; set; }


    }
}
