namespace RegulationAssessment.Api.Models
{
    public class NotificationListDataModel
    {
        public DateTime date { get; set; }
        public List<NotificationModel> data { get; set; }
    }

    public class NotificationModel
    {
        public string type { get; set; }
        public string title { get; set; }
        public string content { get; set; }
        public DateTime time { get; set; }
        public bool readStatus { get; set; }
    }

}
