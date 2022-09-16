using RegulationAssessment.Common.Enum;
using RegulationAssessment.Logic.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegulationAssessment.Api.Models
{
    public class TaskItemModel
    {
        public Guid TaskId { get; set; }
        public string TaskTitle { get; set; }
        public string LocationName { get; set; }
        public DateTime DueDate { get; set; }
        public TaskProcess? Process { get; set; }
        public TaskTimeStatus DatetimeStatus { get; set; }
    }

    public class TaskListSortByProcessModel
    {
        public TaskProcess TaskProcess { get; set; }
        public List<TaskItemModel> TaskList { get; set; }
    }

    public class TaskInfoModel
    {
        public Guid TaskId { get; set; }
        public string TaskTitle { get; set; }
        public string LocationName { get; set; }
        public DateTime DueDate { get; set; }
        public string ActType { get; set; }
        public int TotalKeyAct { get; set; }
        public TaskTimeStatus DatetimeStatus { get; set; }
    }

    public class TaskAssessmentModel
    {
        public Guid TaskId { get; set; }
        public Guid EmployeeId { get; set; }
        public TaskProcess Process { get; set; }
        public List<KeyActionAssessmentModel> KeyActionList { get; set; }
    }

    public class KeyActionAssessmentModel
    {
        public Guid KeyActId { get; set; }
        public bool IsChecked { get; set; }
        public string Notation { get; set; }
        public List<Guid>? ResponsePersonId { get; set; }
        public int? Cost { get; set; }
        public DateTime? DueDate { get; set; }
    }
}
