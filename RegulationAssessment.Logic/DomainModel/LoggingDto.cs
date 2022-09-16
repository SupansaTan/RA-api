namespace RegulationAssessment.Logic.DomainModel
{
    public class LoggingAssessmentDto
    {
        public Guid Id { get; set; }
        public int Process { get; set; }
        public bool Status { get; set; }
        public string Notation { get; set; }
        public Guid KeyActId { get; set; }
    }

    public class ConsistanceAssessmentDto
    {
        public bool Status { get; set; }
        public string Notation { get; set; }
        public List<string>? ResponsiblePersonList { get; set; }
        public int? Cost { get; set; }
        public DateTime? DueDate { get; set; }
    }

    public class LoggingAllHistoryListDto
    {
        public int KeyActOrder { get; set; }
        public List<LoggingAllHistoryDto> LoggingList { get; set; }
    }

    public class LoggingAllHistoryDto
    {
        public DateTime CreateDate { get; set; }
        public string EmployeeName { get; set; }
        public string TaskProcessTitle { get; set; }
    }
}