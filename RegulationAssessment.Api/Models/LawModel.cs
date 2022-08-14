namespace RegulationAssessment.Api.Models
{
    public class LawModel
    {
        public Guid LawId { get; set; }
        public string Title { get; set; }
        public string LegislationType { get; set; }
    }

    public class LawListModel
    {
        public int TotalLaw { get; set; }
        public List<LawModel> LawList { get; set; }
    }

    public class LawListFilterModel
    {
        public string? Keyword { get; set; }
        public string? Catagory { get; set; }
        public string? ActType { get; set; }
        public string? LegislationUnit { get; set; }
        public DateTime? AnnounceDate { get; set; }
        public DateTime? EnforceDate { get; set; }
        public DateTime? CancelDate { get; set; }
        public bool IsFilterByAnnounceDate { get; set; }
        public bool IsFilterByEnforceDate { get; set; }
        public bool IsFilterByCancelDate { get; set; }
    }
}
