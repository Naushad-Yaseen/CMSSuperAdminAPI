using Entities.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessLayer.Entities
{
   public class StudentSubject: BaseEntity
    {
        [Key]
        public long StudentSubjectID { get; set; }

        [Required(ErrorMessage = "Student ID  is required")]
        [Display(Name = "Student ID")]
        public long StudentID { get; set; }

        [Required(ErrorMessage = "Subject ID  is required")]
        [Display(Name = "Subject ID")]
        public int SubjectID { get; set; }
        public bool IsCore { get; set; }
        public int SubjectEnrollmentStatusID { get; set; }
        [Required(ErrorMessage = "Class ID  is required")]
        [Display(Name = "Class ID")]
        public int ClassID { get; set; }


        [Required(ErrorMessage = "Section ID  is required")]
        [Display(Name = "Section ID")]
        public int SectionID { get; set; }

        [Required(ErrorMessage = "Academic Session ID  is required")]
        [Display(Name = "Academic Session ID")]
        public int AcademicSessionID { get; set; }


    }
}
