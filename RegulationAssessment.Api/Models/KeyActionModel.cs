
namespace RegulationAssessment.Api.Models
{
    public class KeyActionModel
    {
        public Guid Id { get; set; }
        public string KeyReq { get; set; }
        public string Standard { get; set; }
        public string Practice { get; set; }
        public string Frequency { get; set; }
        public int Order { get; set; }
        public Guid LawId { get; set; }
    }
    public class TaskKeyActionModel
    {
        public Guid Id { get; set; }
        public Guid TaskId { get; set; }
        public Guid KeyActId { get; set; }
    }
}
