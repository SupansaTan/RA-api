using RegulationAssessment.Logic.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegulationAssessment.Logic.Services.Interfaces
{
    public interface ILoggingService
    {
        List<LoggingDto> GetLoggingByTaskKeyactId(Guid taskkeyactId);
        
    }
}