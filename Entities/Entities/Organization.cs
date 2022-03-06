using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
     public class Organization: BaseEntity
    {
        [Key]
        [Display(Name = "Organization ID")]
        public int OrganizationID { get; set; }

        [Required(ErrorMessage = "The Organization Name is required")]
        [Display(Name = "Organization Name")]
        [StringLength(50, ErrorMessage = "Organization Name cannot be longer than 50 characters.")]
        public string OrganizationName { get; set; }


        [Display(Name = "Organization  Short Name")]
        [StringLength(30, ErrorMessage = "Organization Short Name cannot be longer than 30 characters.")]
        public string OrganizationShortName { get; set; }

        [Required(ErrorMessage = "The Contact Person Full Name is required")]
        [Display(Name = "Contact Person Full Name")]
        [StringLength(50, ErrorMessage = "Contact Person Full Name cannot be longer than 50 characters.")]
        public string ContactPersonFullName { get; set; }


        [Display(Name = "Email address")]
        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [MaxLength(75)]
        public string Email { get; set; }

        [Required(ErrorMessage = "You must provide a contact number")]
        [Display(Name = "Contact Number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        [MaxLength(75)]
        public string ContactNumber { get; set; }

        [Display(Name = "Contact Number Country Code")]
        [Required(ErrorMessage = "You must provide a contact number country code")]
        [MaxLength(10)]
        public string ContactNumberCountryCode { get; set; }

        [Display(Name = "User Name")]
        [Required(ErrorMessage = "You must provide a User Name")]
        [StringLength(50, ErrorMessage = "UserName cannot be longer than 50 characters.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "The Password  is required")]
        //[StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [RegularExpression(@"^((?=.*[a-z])(?=.*[A-Z])(?=.*\d)).+$")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Sub Domain Name")]
        [Required(ErrorMessage = "The Subdomain Name is  required")]
        [StringLength(50, ErrorMessage = "SubDomainName cannot be longer than 50 characters.")]
        public string SubDomainName { get; set; }

        [Display(Name = "Organization Type")]
        [Required(ErrorMessage = "The Organization Type  is required")]
        [MaxLength(50)]
        public string OrganizationType { get; set; }

        [Display(Name = "Maximum Student Allowed")]
        [Required(ErrorMessage = "The Maximum Student Allowed is required")]
        [MaxLength(50)]
        public string MaximumStudentAllowed { get; set; }

        [Display(Name = "Connection String Name")]
        [Required(ErrorMessage = "The Connection String  is required")]
        [MaxLength(50)]
        public string ConnectionStringName { get; set; }

        [Display(Name = "Organization DataBase")]
        [Required(ErrorMessage = "The Organization Database Name is required")]
        [MaxLength(50)]
        public string OrganizationDatabaseName { get; set; }

        [Required]
        [Display(Name = "Status ID")]
        public int StatusID { get; set; }

        //[ForeignKey("StatusID")]
        //public virtual Status Status { get; set; }

        [Required]
        public bool IsEmailVerified { get; set; }

        //[Required(ErrorMessage = "The Verification Date is required")]
        //[DataType(DataType.Date)]
        //[Display(Name = "Verification Date")]
        //public DateTime VerificationDate { get; set; }


        //[Display(Name = "Subscription  ID")]
        //public int SubscriptionID { get; set; }

        //[ForeignKey("SubscriptionID")]
        //public virtual SubscriptionPlan SubscriptionPlan { get; set; }

        //[Required(ErrorMessage = "The Subscription Start Date is required")]
        //[DataType(DataType.Date)]
        //[Display(Name = "Subscription Start Date")]
        //public DateTime SubscriptionStartDate { get; set; }

        //[Required(ErrorMessage = "The Subscription End Date is required")]
        //[Display(Name = "Subscription End Date")]
        //public DateTime SubscriptionEndDate { get; set; }

        //[Display(Name = "Email Subscription Plan ID")]
        //public int EmailSubscriptionPlanID { get; set; }

        //[ForeignKey("EmailSubscriptionPlanID")]
        //public virtual EmailSubscriptionPlan EmailSubscriptionPlan { get; set; }


        //[Display(Name = "SMS Subscription Plan ID")]
        //public int SmsSubscriptionPlanID { get; set; }

        //[ForeignKey("SmsSubscriptionPlanID")]
        //public virtual SMSSubscriptionPlan SMSSubscriptionPlan { get; set; }
    }
}
