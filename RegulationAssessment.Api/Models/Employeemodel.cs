using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegulationAssessment.Api.Models
{
    public class EmployeeModel
    {
        public Guid Id { get; set; }
        public string? Ssn { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime CreateAt { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public bool? DarkTheme { get; set; }
        public bool NotificationStatus { get; set; }
        public int AdvanceNotify { get; set; }
    }
}
