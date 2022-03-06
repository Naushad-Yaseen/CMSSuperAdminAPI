using Entities.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessLayer.Entities
{
   public class SubjectEnrollmentStatus: BaseEntity
    {
        [Key]
        public int SubjectEnrollmentStatusID { get; set; }
        [Required]
        [StringLength(20)]
        [Display(Name = "Subject Enrollment Status Name")]
        public string SubjecttEnrollmentStatusName { get; set; }
    }
}
