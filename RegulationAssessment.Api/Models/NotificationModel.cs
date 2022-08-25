namespace RegulationAssessment.Api.Models
{
    public class NotificationModel
    {
        public string LawTitle { get; set; }
        public int Process { get; set; }
        public DateTime NotifyDate { get; set; }
        public bool Read { get; set; }
    }
}
