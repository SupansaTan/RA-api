using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegulationAssessment.Logic.DomainModel
{
    public class NotificationDateDto
    {
        public DateTime date { get; set; }
    }

    public class NotificationDto
    {
        public string type { get; set; }
        public string title { get; set; }
        public string content { get; set; }
        public DateTime time { get; set; }
        public bool readStatus { get; set; }
    }
}
