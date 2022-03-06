using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessLayer.Entities
{
   public class Student:BaseEntity
    {
        [Key]
        [Display(Name = "Student ID")]
        public long StudentID { get; set; }

        [Required]
        [MaxLength(10)]
       // [Index(IsUnique = true)]
        [Display(Name = "Admission Number")]
        public string AdmissionNumber { get; set; }

        [Required(ErrorMessage = "The First Name is required")]
        [Display(Name = "First Name")]
        [StringLength(50, ErrorMessage = "FirstName cannot be longer than 50 characters.")]
        public string FirstName { get; set; }


        [Display(Name = "Middle Name")]
        [StringLength(50, ErrorMessage = "MiddleName cannot be longer than 50 characters.")]
        public string MiddleName { get; set; }


        [Required(ErrorMessage = "The Last Name is required")]
        [Display(Name = "Last Name")]
        [StringLength(50, ErrorMessage = "LastName cannot be longer than 50 characters.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "You must provide a contact number")]
        [Display(Name = "Contact Number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]

        public string ContactNumber { get; set; }


        [Required(ErrorMessage = "The Gender is required")]
        public int GenderID { get; set; }

        [Required(ErrorMessage = "The Blood Group is required")]
        public int BloodGroupID { get; set; }


        [Display(Name = "Email address")]
        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [StringLength(75)]
        public string Email { get; set; }


        [Required(ErrorMessage = "The Date of Birth is required")]
        [DataType(DataType.Date)]
        [Display(Name = "Date Of Birth")]
        public DateTime DateOfBirth { get; set; }


        [MaxLength(50)]
        //[Required(ErrorMessage = "The Address is required")]
        public string Address { get; set; }


        [DataType(DataType.PostalCode)]
        //[Required(ErrorMessage = "The zip Code is required")]
        [MaxLength(8)]
        public string ZipCode { get; set; }
        public int? StateID { get; set; }


        public int? CountryID { get; set; }


        //[Required(ErrorMessage = "The City is required")]
        [StringLength(50)]
        public string City { get; set; }

        [Display(Name = "Profile Picture")]
        [DataType(DataType.ImageUrl)]
        [StringLength(50)]
        public string ProfilePhoto { get; set; }
        // [Required(ErrorMessage = "The StudentSkillID is required")]
        public string StudentSkillID { get; set; }

        [MaxLength(250)]
        public string ProfileSummary { get; set; }

        [DataType(DataType.Url)]
        public string FacebookLink { get; set; }

        [DataType(DataType.Url)]
        public string LinkedInlink { get; set; }

        [Display(Name = "Contact Number Country Code")]
        [MaxLength(10)]
        public string ContactNumberCountryCode { get; set; }
        public Guid UserID { get; set; }
        [DefaultValue("false")]
        [Display(Name = "Block")]
        public bool? Block { get; set; }

        [DefaultValue("false")]
        [Display(Name = "Alumni")]
        public bool? Alumni { get; set; }
        public string StudentExtraInfoInJson { get; set; }
    }
}
