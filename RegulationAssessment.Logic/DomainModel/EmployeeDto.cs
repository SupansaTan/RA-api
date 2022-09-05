using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegulationAssessment.Logic.DomainModel
{
    public class EmployeeDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime CreateAt { get; set; }
        public bool DarkTheme { get; set; }
        public bool NotificationStatus { get; set; }
        public int AdvanceNotify { get; set; }
    }

    public class EmployeeProfileDto
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<RoleInfoDto> RoleList { get; set; }
    }

    public class RoleInfoDto
    {
        public string RoleName { get; set; }
        public string Location { get; set; }
    }

    public class UpdateEmployeeInfoDto
    {
        public Guid EmployeeId { get; set; }
        public bool DarkTheme { get; set; }
        public bool NotificationStatus { get; set; }
        public int AdvanceNotify { get; set; }
    }

    public class EmployeeInfoDto
    {
        public Guid EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
