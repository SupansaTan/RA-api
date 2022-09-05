using RegulationAssessment.Common.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegulationAssessment.Logic.DomainModel
{
    public class TaskDto
    {
        public Guid Id { get; set; }
        public Guid LocationId { get; set; }
        public Guid LawId {get; set;}
        public int Process { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime CompleteDate { get; set; }
    }

    public class TaskItemDto
    {
        public Guid TaskId { get; set; }
        public string TaskTitle { get; set; }
        public string LocationName { get; set; }
        public DateTime DueDate { get; set; }
        public TaskProcess? Process { get; set; }
        public TaskTimeStatus DatetimeStatus { get; set; }
    }

    public class TaskDataDto
    {
        public Guid TaskId { get; set; }
        public string TaskTitle { get; set; }
        public string LocationName { get; set; }
    }

    public class TaskListSortByProcessDto
    {
        public TaskProcess TaskProcess { get; set; }
        public List<TaskItemDto> TaskList { get; set; }
    }

    public class TaskDetailDto
    {
        public string TaskTitle { get; set; }
        public string Catagory { get; set; }
        public string ActType { get; set; }
        public string LegislationType { get; set; }
        public string LegislationUnit { get; set; }
        public DateTime AnnounceDate { get; set; }
        public DateTime EnforceDate { get; set; }
    }

    public class TaskInfoDto
    {
        public Guid TaskId { get; set; }
        public string TaskTitle { get; set; }
        public string LocationName { get; set; }
        public DateTime DueDate { get; set; }
        public string ActType { get; set; }
        public int TotalKeyAct { get; set; }
        public TaskTimeStatus DatetimeStatus { get; set; }
    }

    public class TaskAssessmentDto
    {
        public Guid TaskId { get; set; }
        public Guid EmployeeId { get; set; }
        public TaskProcess Process { get; set; }
        public List<KeyActionAssessmentDto> KeyActionList { get; set; }
    }

    public class KeyActionAssessmentDto
    {
        public Guid KeyActId { get; set; }
        public bool IsChecked { get; set; }
        public string Notation { get; set; }
        public List<Guid>? ResponsePersonId { get; set; }
        public int? Cost { get; set; }
        public DateTime? DueDate { get; set; }
    }

    public class ResponsibleDataDto
    {
        public List<Guid> EmployeeId { get; set; }
        public int Cost { get; set; }
        public DateTime DueDate { get; set; }
    }
}
