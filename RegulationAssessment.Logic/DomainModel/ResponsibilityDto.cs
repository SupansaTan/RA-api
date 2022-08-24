using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegulationAssessment.Logic.DomainModel
{
    public class ResponsibilityDto
    {
        public Guid Id { get; set; }
        public Guid EmpId { get; set; }
        public decimal Cost { get; set; }
        public DateTime DueDate { get; set; }
        public Guid TaskKeyActId { get; set; }
        public bool Status { get; set; }
    }
}
