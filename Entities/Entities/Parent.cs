using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessLayer.Entities
{
   public  class Parent:BaseEntity
    {
        [Key]
        public long ParentID { get; set; }

        [MaxLength(10)]
       // [Index(IsUnique = true)]

        [Required(ErrorMessage = "The Parents Number is required")]
        public string ParentsNumber { get; set; }

        [Required(ErrorMessage = "The Father Name is required")]

        [StringLength(50, ErrorMessage = "FatherName cannot be longer than 50 characters.")]
        public string FatherName { get; set; }

        [Required(ErrorMessage = "The Mother Name is required")]
        [StringLength(50, ErrorMessage = "MotherName cannot be longer than 50 characters.")]
        public string MotherName { get; set; }

        [Display(Name = "Guardian Name")]
        [StringLength(50, ErrorMessage = "GuardianName cannot be longer than 50 characters.")]
        public string GuardianName { get; set; }


        [Required(ErrorMessage = "You must provide a contact number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]

        public string ParentContact { get; set; }

        [Required(ErrorMessage = "You must provide a Email Address")]
        [Display(Name = "Email address")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [StringLength(75)]

        public string ParentEmail { get; set; }


        [Display(Name = "Contact Number")]
        [DataType(DataType.PhoneNumber)]
        public string GuardianContact { get; set; }


        [Display(Name = "Guardian address")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [StringLength(75)]
        public string GuardianEmail { get; set; }


        public Guid UserID { get; set; }
    }
}
