using Entities.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessLayer.Entities
{
   public class EnrollmentStatus : BaseEntity
    {
        [Key]
        public int StudentEnrollmentStatusID { get; set; }
        [Required]
        [StringLength(20)]
        [Display(Name = "Student Enrollment Status Name")]
        public string StudentEnrollmentStatusName { get; set; }
    }
}
