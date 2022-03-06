using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OLO.ViewModels.Models
{
    public class AcademicSessionStatusDropDown
    {
        public int AcademicSessionStatusID { get; set; }
        public string AcademicSessionStatusName { get; set; }
    }
    public class AcademicSessionDropDown
    {
        public int AcademicSessionID { get; set; }
        public string AcademicSessionName { get; set; }
    }

    public class classDropDown
    {
        public int ClassID { get; set; }
        public string ClassName { get; set; }
    }

    public class sectionDropDown
    {
        public int SectionID { get; set; }
        public string SectionName { get; set; }
    }


    public class subjectDropDown
    {
        public int SubjectID { get; set; }
        public string SubjectName { get; set; }
    }

    public class departmentDropDown
    {
        public int DepartmentID { get; set; }
        public string DepartmentName { get; set; }
    }
}
