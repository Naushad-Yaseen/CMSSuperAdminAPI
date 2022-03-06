using Entities.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessLayer.Entities

{
   public class Subject: BaseEntity
    {
        [Key]
        public int SubjectID { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Subject Name cannot be longer than 50 characters.")]

        public string SubjectName { get; set; }

        [Required]
        [MaxLength(10)]
        public string SubjectCode { get; set; }

        [Required]
        [MaxLength(10)]
        public string SubjectCredit { get; set; }

        public bool IsCore { get; set; }

        [Required(ErrorMessage = "Class ID  is required")]
        [Display(Name = "Class ID")]
        public int ClassID { get; set; }

        //[Required]
        //[ForeignKey("ClassID")]
        //public virtual Class Class { get; set; }

        [Required(ErrorMessage = "Section ID  is required")]
        [Display(Name = "Section ID")]
        public int SectionID { get; set; }

        //[Required]
        //[ForeignKey("SectionID")]
        //public virtual Section Section { get; set; }

        [Required]
        public int IndexNo { get; set; }
        public int SubjectEnrollmentStatusID { get; set; }
    }
}
