using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegulationAssessment.Api.Models
{
    public class EmployeeModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool? DarkTheme { get; set; }
        public bool NotificationStatus { get; set; }
        public int AdvanceNotify { get; set; }
    }

    public class EmployeeProfileModel
    {
        public string Email { get; set; }
        public List<RoleInfoModel> RoleList { get; set; }
    }

    public class RoleInfoModel
    {
        public string RoleName { get; set; }
        public string Location { get; set; }
    }
}
