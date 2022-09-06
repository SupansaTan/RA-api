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
        Task<List<LoggingAssessmentDto>> GetLogging(Guid taskId, int process);
        Task<bool> AddKeyActionLog(Logging logging);
        Task<List<LoggingAllHistoryListDto>> GetAllLogging(Guid taskId);
    }
}