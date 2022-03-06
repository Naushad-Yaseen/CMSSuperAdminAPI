using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OLO.ViewModels.Models
{
   public class StudentDetailsByClassIdSectionIdAcademicIdModel
    {
        public long StudentID { get; set; }
        //public long ParentID { get; set; }
        public int AcademicSessionID { get; set; }
        public int ClassID { get; set; }
        public int SectionID { get; set; }
       
        public string AdmissionNumber { get; set; }
        public string FullName { get; set; }
        public string ContactNumber { get; set; }

        public int GenderID { get; set; }
        public int BloodGroupID { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public int? StateID { get; set; }
        public int? CountryID { get; set; }

        public string City { get; set; }

        public string ProfilePhoto { get; set; }

        public string StudentSkillID { get; set; }

        public string ProfileSummary { get; set; }

        public string FacebookLink { get; set; }

        public string LinkedInlink { get; set; }

        public string ContactNumberCountryCode { get; set; }
        public Guid UserID { get; set; }

        public string StudentExtraInfoInJson { get; set; }
        public string ParentsNumber { get; set; }

        public string FatherName { get; set; }

        public string MotherName { get; set; }

        public string GuardianName { get; set; }

        public string ParentContact { get; set; }

        public string ParentEmail { get; set; }

        public string ClassName { get; set; }
        public string AcademicSessionName { get; set; }
        public string SectionName { get; set; }

        public string GuardianEmail { get; set; }
    }
}
