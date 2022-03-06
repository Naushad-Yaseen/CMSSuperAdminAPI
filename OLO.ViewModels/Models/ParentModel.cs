using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OLO.ViewModels.Models
{
   public class ParentModel
    {
        public long ParentID { get; set; }

        public string ParentsNumber { get; set; }

        public string FatherName { get; set; }

        public string MotherName { get; set; }

        public string GuardianName { get; set; }

        public string ParentContact { get; set; }

        public string ParentEmail { get; set; }

        public string GuardianContact { get; set; }

        public string GuardianEmail { get; set; }
        public Guid UserID { get; set; }
    }
}
