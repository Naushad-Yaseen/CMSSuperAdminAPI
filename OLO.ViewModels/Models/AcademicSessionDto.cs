using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OLO.ViewModels.Models
{
   public class AcademicSessionDto
    {
       
        public int AcademicSessionID { get; set; }

    
        public string AcademicSessionName { get; set; }

        
        public DateTime StartDate { get; set; }

    
        public DateTime EndDate { get; set; }

        
        public int AcademicSessionStatusID { get; set; }

        public bool IsLocked { get; set; }

        public int LockedBy { get; set; }

      
        public DateTime LockedDate { get; set; }
    }
}
