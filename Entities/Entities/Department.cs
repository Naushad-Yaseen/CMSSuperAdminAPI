using Entities.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessLayer.Entities
{
   public class Department: BaseEntity
    {
        [Key]
        public int DepartmentID { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Department name cannot be longer than 50 characters.")]
        public string DepartmentName { get; set; }

        [Required(ErrorMessage = "Academic Session is required")]
        [Display(Name = "AcademicSession ID")]
        public int AcademicSessionID { get; set; }

        //[Required]
        //[ForeignKey("AcademicSessionID")]
        //public virtual AcademicSession AcademicSession { get; set; }
        [Required]
        public int IndexNo { get; set; }
    }
}
