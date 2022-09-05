using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegulationAssessment.Common.Enum
{
    public enum TaskProcess : int
    {
        Relevant = 1,
        ApproveRelevant = 2,
        Consistance = 3,
        ApproveConsistance = 4,
        Response = 5,
        ApproveResponse = 6,
        Done = 7,
    }
}
