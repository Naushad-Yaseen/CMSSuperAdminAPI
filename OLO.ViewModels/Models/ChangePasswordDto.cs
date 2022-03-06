using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OLO.ViewModels.Models
{
   public class ChangePasswordDto
    {
        public int OrganizationID { get; set; }
       // public string Password { get; set; }
        public string newPassword { get; set; }
    }
}
