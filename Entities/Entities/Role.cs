using Entities.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessLayer.Entities
{
   public class Role:BaseEntity
    {
        [Key]
        [Display(Name = "Role ID")]
        public int RoleID { get; set; }

        [Display(Name = "Role Name")]
        [Required(ErrorMessage = "The Role Name is required")]
        [StringLength(50, ErrorMessage = "Role Name cannot be longer than 50 characters.")]
        public string RoleName { get; set; }

        [Display(Name = "Role Description")]
        [MaxLength(1000)]
        public string RoleDescription { get; set; }
    }
}
