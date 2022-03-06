using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
   public class BaseEntity
    {
        [DefaultValue("true")]
        public bool IsActive { get; set; }
        [DefaultValue("false")]
        public bool IsDeleted { get; set; }
        [DataType(DataType.Date)]
        [Required]
        public DateTime CreatedDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime? DeletedDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime? ModifiedDate { get; set; }
        [Required]
        public Guid CreatedBy { get; set; }
        public Guid? DeletedBy { get; set; }
        public Guid? ModifyBy { get; set; }
    }
}
