using Entities.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessLayer.Entities
{
   public class Classess: BaseEntity
    {
        [Key]
        public int ClassID { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "ClassName cannot be longer than 50 characters.")]
        public string ClassName { get; set; }

        [Required]
        [MaxLength(20)]
        public string ClassCode { get; set; }

        [Required]
        [MaxLength(20)]
        public int StudentsLimit { get; set; }

        [Display(Name = "Department ID")]

        public int DepartmentID { get; set; }


        [Required]
        public int IndexNo { get; set; }
    }
}
