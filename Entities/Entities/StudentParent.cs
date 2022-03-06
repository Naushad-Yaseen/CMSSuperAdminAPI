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
   public class StudentParent:BaseEntity
    {
        [Key]
        [Display(Name = "Student Parent ID")]
        public long StudentParentID { get; set; }

        [Display(Name = "Parent ID")]
        [Required(ErrorMessage = "Parent Id  is required")]
        public long ParentID { get; set; }

        [ForeignKey("ParentID")]
        public virtual Parent Parent { get; set; }

        [Display(Name = "Student ID")]
        [Required(ErrorMessage = "Student ID  is required")]
        public long StudentID { get; set; }

        [ForeignKey("StudentID")]
        public virtual Student Student { get; set; }
    }
}
