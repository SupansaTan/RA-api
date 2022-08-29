using RegulationAssessment.DataAccess.EntityFramework.Models;
using RegulationAssessment.Logic.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = RegulationAssessment.DataAccess.EntityFramework.Models.Task;

namespace RegulationAssessment.Logic.Services.Interfaces
{
    public interface ILoggingService
    {
        List<LoggingDto> GetLoggingByTaskKeyactId(Guid taskkeyactId);
        Task<bool> AddKeyActionLog(Logging logging);
    }
}