using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OLO.ViewModels.Models
{
   public class ClassModel
    {
        public int ClassID { get; set; }
        public string ClassName { get; set; }
        public string ClassCode { get; set; }
        public int StudentsLimit { get; set; }
        public int DepartmentID { get; set; }
        public int IndexNo { get; set; }
    }
}
