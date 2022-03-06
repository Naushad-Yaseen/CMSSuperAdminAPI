using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OLO.ViewModels.Models
{
   public class SectionModel
    {
        public int SectionID { get; set; }
        public string SectionName { get; set; }
        public string SectionCode { get; set; }
        public int StudentsLimit { get; set; }
        public int ClassID { get; set; }
        public int IndexNo { get; set; }
    }
}
