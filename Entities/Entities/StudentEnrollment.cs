using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Domain.Entities
{
   public class StudentEnrollment : CommonClass
    {
        [Key]
        public int StudentEnrollmentID { get; set; }
        [Required]
        [Display(Name = "Acaemic Session")]
        public int AcademicSessionID { get; set; }
        [Required]
        [Display(Name = "Class")]
        public int ClassID { get; set; }
        [Required]
        [Display(Name = "Section")]
        public int SectionID { get; set; }
        [Required]
        [Display(Name = "Student Enrollment Status")]
        public int StudentEnrollmentStatusID { get; set; }
        [Required]
        [ForeignKey("AcademicSessionID")]
        public virtual AcademicSession AcademicSession { get; set; }

        [Required]
        [ForeignKey("ClassID")]
        public virtual Class Class { get; set; }

        [Required]
        [ForeignKey("SectionID")]
        public virtual Section Section { get; set; }
        [Required]
        [Display(Name = "Student")]
        public long StudentID { get; set; }

       
    }
}
