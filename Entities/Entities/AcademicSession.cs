using Entities.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessLayer.Entities
{
   public class AcademicSession:BaseEntity
    {
        [Key]
        public int AcademicSessionID { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "AcademicSessionName cannot be longer than 50 characters.")]
        public string AcademicSessionName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd}")]
       // [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd}")]
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }

        [Required]
        public int AcademicSessionStatusID { get; set; }

        public bool IsLocked { get; set; }

        public int LockedBy { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Locked Date")]
        public DateTime LockedDate { get; set; }
    }
}
