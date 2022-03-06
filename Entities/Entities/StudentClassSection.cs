using Entities.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessLayer.Entities
{
   public class StudentClassSection:BaseEntity
    {
        [Key]
        public long StudentClassSectionID { get; set; }

        [Required(ErrorMessage = "Student ID  is required")]
        [Display(Name = "Student ID")]
        public long StudentID { get; set; }

        [Required(ErrorMessage = "Academic Session ID  is required")]
        [Display(Name = "Academic Session ID")]
        public int AcademicSessionID { get; set; }

        [Required(ErrorMessage = "Class ID  is required")]
        [Display(Name = "Class ID")]
        public int ClassID { get; set; }

        [Required(ErrorMessage = "Section ID  is required")]
        [Display(Name = "Section ID")]

        public int SectionID { get; set; }

        [Display(Name = "Department ID")]
        public int? DepartmentID { get; set; }

        //[Required]
        //[ForeignKey("ClassID")]
        //public virtual Classess Class { get; set; }

        //[Required]
        //[ForeignKey("SectionID")]
        //public virtual Section Section { get; set; }
        //[Required]
        //[ForeignKey("AcademicSessionID")]
        //public virtual AcademicSession AcademicSession { get; set; }

        //[Required]
        //[ForeignKey("StudentID")]
        //public virtual Student Student { get; set; }
    }
}
