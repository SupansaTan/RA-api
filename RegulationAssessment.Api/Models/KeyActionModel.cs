
namespace RegulationAssessment.Api.Models
{
    public class KeyActionModel
    {
        public Guid Id { get; set; }
        public string KeyReq { get; set; } = null!;
        public string? Standard { get; set; }
        public string? Practice { get; set; }
        public string? Frequency { get; set; }
        public int Order { get; set; }
        public Guid LawId { get; set; }
    }
}
