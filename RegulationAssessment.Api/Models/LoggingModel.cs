namespace RegulationAssessment.Api.Models
{
    public class LoggingModel
    {
        public Guid Id { get; set; }
        public DateTime CreateDate { get; set; }
        public string? Notation { get; set; }
        public int Process { get; set; }
        public bool Status { get; set; }
        public Guid TaskKeyActId { get; set; }
        public Guid RespId { get; set; }
        public Guid EmpId { get; set; }
    }
}