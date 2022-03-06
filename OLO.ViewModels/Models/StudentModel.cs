using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OLO.ViewModels.Models
{
    public class StudentModel
    {
        public long StudentID { get; set; }
        public long ParentID { get; set; }
        public int AcademicSessionID { get; set; }
        public int ClassID { get; set; }
        public int SectionID { get; set; }
        public int SubjectID { get; set; }
        public int? DepartmentID { get; set; }
        public string AdmissionNumber { get; set; }

        public string FirstName { get; set; }
        public string FullName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }
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

        public bool? Block { get; set; }

        public bool? Alumni { get; set; }
        public string StudentExtraInfoInJson { get; set; }
        public string ParentsNumber { get; set; }

        public string FatherName { get; set; }

        public string MotherName { get; set; }

        public string GuardianName { get; set; }

        public string ParentContact { get; set; }

        public string ParentEmail { get; set; }

        public string GuardianContact { get; set; }

        public string GuardianEmail { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
    }
}
