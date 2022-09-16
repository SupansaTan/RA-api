using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegulationAssessment.Logic.DomainModel
{
    public class ResponsibilityListDto
    {
        public string LocationName { get; set; }
        public List<ResponsibilityDetailDto> DoneTask { get; set; }
        public List<ResponsibilityDetailDto> InProgressTask { get; set; }
    }

    public class ResponsibilityDetailDto
    {
        public Guid TaskId { get; set; }
        public string TaskTitle { get; set; }
        public DateTime DueDate { get; set; }
        public bool Status { get; set; }
        public string EmployeeName { get; set; }
        public int DatetimeStatus { get; set; }
        
    }
}
