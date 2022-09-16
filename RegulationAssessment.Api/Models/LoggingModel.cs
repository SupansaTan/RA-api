namespace RegulationAssessment.Api.Models
{
    public class LoggingAssessmentModel
    {
        public Guid Id { get; set; }
        public int Process { get; set; }
        public bool Status { get; set; }
        public string Notation { get; set; }
        public Guid KeyActId { get; set; }
    }

    public class ConsistanceAssessmentModel
    {
        public bool Status { get; set; }
        public string Notation { get; set; }
        public List<string>? ResponsiblePersonList { get; set; }
        public int? Cost { get; set; }
        public DateTime? DueDate { get; set; }
    }

    public class LoggingAllHistoryListModel
    {
        public int KeyActOrder { get; set; }
        public List<LoggingAllHistoryModel> LoggingList { get; set; }
    }

    public class LoggingAllHistoryModel
    {
        public DateTime CreateDate { get; set; }
        public string EmployeeName { get; set; }
        public string TaskProcessTitle { get; set; }
    }
}