using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OLO.ViewModels.Models
{
   public class SubjectModel
    {
        public int SubjectID { get; set; }
        public string SubjectName { get; set; }

        public string SubjectCode { get; set; }

        public string SubjectCredit { get; set; }

        public bool IsCore { get; set; }
        public int ClassID { get; set; }
        public int SectionID { get; set; }
        public int IndexNo { get; set; }
        public int SubjectEnrollmentStatusID { get; set; }
    }
}
