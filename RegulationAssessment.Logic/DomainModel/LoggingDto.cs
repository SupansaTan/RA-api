namespace RegulationAssessment.Logic.DomainModel
{
    public class LoggingDto
    {
        public Guid Id { get; set; }
        public DateTime CreateDate { get; set; }
        public string? Notation { get; set; }
        public int Process { get; set; }
        public bool Status { get; set; }
        public Guid TaskKeyActId { get; set; }
        public Guid? RespId { get; set; }
        public Guid EmpId { get; set; }
    }

    public class LoggingAssessmentDto
    {
        public Guid Id { get; set; }
        public int Process { get; set; }
        public bool Status { get; set; }
        public string Notation { get; set; }
        public Guid KeyActId { get; set; }
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