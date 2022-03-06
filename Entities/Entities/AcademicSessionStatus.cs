using Entities.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessLayer.Entities
{
   public class AcademicSessionStatus:BaseEntity
    {
        [Key]
        public int AcademicSessionStatusID { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "AcademicSessionStatusName cannot be longer than 50 characters.")]
        public string AcademicSessionStatusName { get; set; }
    }
}
