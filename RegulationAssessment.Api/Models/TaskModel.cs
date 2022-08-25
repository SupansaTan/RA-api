using RegulationAssessment.Common.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegulationAssessment.Api.Models
{
    public class TaskModel
    {
        public Guid Id { get; set; }
        public Guid LocationId { get; set; }
        public Guid LawId {get; set;}
        public int Process { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? CompleteDate { get; set; }
    }

    public class TaskItemModel
    {
        public Guid TaskId { get; set; }
        public string TaskTitle { get; set; }
        public string LocationName { get; set; }
        public DateTime DueDate { get; set; }
        public int? Process { get; set; }
        public TaskTimeStatus DatetimeStatus { get; set; }
    }
}
