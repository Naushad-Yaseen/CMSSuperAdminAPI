using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OLO.ViewModels.Models
{
   public class StudentClassSectionModel
    {
        public long StudentClassSectionID { get; set; }
        public long StudentID { get; set; }
        public int AcademicSessionID { get; set; }

        public int ClassID { get; set; }
        public int SectionID { get; set; }
    }
}
