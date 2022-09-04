using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegulationAssessment.Logic.DomainModel
{
    public class LawDto
    {
        public Guid LawId { get; set; }
        public string Title { get; set; }
        public string LegislationType { get; set; }
    }

    public class LawListDto
    {
        public int TotalLaw { get; set; }
        public List<LawDto> LawList { get; set; }
    }

    public class LawListFilterDto
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

    public class LawDetailDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string? LocationName { get; set; }
        public DateTime AnnounceDate { get; set; }
        public DateTime? EnforceDate { get; set; }
        public DateTime? CancelDate { get; set; }
        public string? PdfUrl { get; set; }
        public string Catagory { get; set; }
        public string ActType { get; set; }
        public string LegislationType { get; set; }
        public string LegislationUnit { get; set; }
        public List<string>? SystemList { get; set; }
    }
}
