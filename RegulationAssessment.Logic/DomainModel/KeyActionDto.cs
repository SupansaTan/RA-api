using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegulationAssessment.Logic.DomainModel
{
    public class KeyActionDto
    {
        public Guid Id { get; set; }
        public string KeyReq { get; set; }
        public string Standard { get; set; }
        public string Practice { get; set; }
        public string Frequency { get; set; }
        public int Order { get; set; }
        public Guid LawId { get; set; }
    }
}
