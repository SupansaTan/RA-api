
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

    public class KeyAssessmentDetail
    {
        public Guid keyActId { get; set; }
        public bool isRelated { get; set; }
        public string notation { get; set; }
    }
}
