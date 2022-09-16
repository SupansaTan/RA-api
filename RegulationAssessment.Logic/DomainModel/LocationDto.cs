using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegulationAssessment.Logic.DomainModel
{
    public class LocationListDto
    {
        public Guid LocationId { get; set; }
        public string LocationName { get; set; }
        public string BusinessType { get; set; }
    }
}
