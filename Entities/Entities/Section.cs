using Entities.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessLayer.Entities
{
   public class Section: BaseEntity
    {
        [Key]
        public int SectionID { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "SectionName cannot be longer than 50 characters.")]
        public string SectionName { get; set; }

        [Required]
        [MaxLength(50)]
        public string SectionCode { get; set; }

        [Required]
        [MaxLength(20)]
        public int StudentsLimit { get; set; }

        [Required(ErrorMessage = "Class ID  is required")]
        [Display(Name = "Class ID")]
        public int ClassID { get; set; }
        [Required]
        public int IndexNo { get; set; }
    }
}
