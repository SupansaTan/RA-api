using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegulationAssessment.Logic.DomainModel
{
    public class NotificationDto
    {
        public string LawTitle { get; set; }
        public int Process { get; set; }
        public DateTime NotifyDate { get; set; }
        public bool Read { get; set; }
    }
}
