using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OLO.ViewModels.Models
{
   public class OrganizationModel
    {
        public int OrganizationID { get; set; }
        public string OrganizationName { get; set; }
        public string OrganizationShortName { get; set; }
        public string ContactPersonFullName { get; set; }
        public string Email { get; set; }
        public string ContactNumber { get; set; }
        public string ContactNumberCountryCode { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string SubDomainName { get; set; }
        public string OrganizationType { get; set; }
        public string MaximumStudentAllowed { get; set; }
        public string ConnectionStringName { get; set; }
        public string OrganizationDatabaseName { get; set; }
        public int StatusID { get; set; }
        public bool IsEmailVerified { get; set; }
      
    }
}
