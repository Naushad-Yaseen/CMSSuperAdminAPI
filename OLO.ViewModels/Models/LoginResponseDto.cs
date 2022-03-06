using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OLO.ViewModels.Models
{
    public class LoginResponseDto
    {
        public string Email { get; set; }
        public string FullName { get; set; }
        public string RoleName { get; set; }
        public Guid UserID { get; set; }
         public int RoleID { get; set; }
        public int OrganizationID { get; set; }
        public string Token { get; set; }
        public string Username { get; set; }
        public string ContactNumber { get; set; }
        public string OrganizationName { get; set; }
    }
}
