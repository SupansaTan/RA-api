using RegulationAssessment.DataAccess.Dapper.Interface;
using RegulationAssessment.DataAccess.EntityFramework.UnitOfWork.Interface;
using RegulationAssessment.Logic.DomainModel;
using RegulationAssessment.Logic.Services.Interfaces;
using RegulationAssessment.Common.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RegulationAssessment.DataAccess.EntityFramework.Models;
using RegulationAssessment.Common.Helper;

namespace RegulationAssessment.Logic.Services.Implements
{
    public class LoggingService : ILoggingService
    {
        private readonly IEntityUnitOfWork _entityUnitOfWork;
        private readonly IDapperUnitOfWork _dapperUnitOfWork;
        private readonly string QUERY_PATH;

        public LoggingService(
            IEntityUnitOfWork entityUnitOfWork,
            IDapperUnitOfWork dapperUnitOfWork
            )
        {
            QUERY_PATH = this.GetType().Name.Split("Service")[0] + "/";
            _entityUnitOfWork = entityUnitOfWork;
            _dapperUnitOfWork = dapperUnitOfWork;
        }

        public async Task<List<LoggingAssessmentDto>> GetLogging(Guid taskId, int process)
        {
                var queryGetLog = QueryService.GetCommand(QUERY_PATH + "getLogging",
                            new ParamCommand { Key = "_taskId", Value = taskId.ToString() }
                        );
                var logList = (await _dapperUnitOfWork.RARepository.QueryAsync<LoggingAssessmentDto>(queryGetLog)).ToList();
                var result = logList.FindAll(x => x.Process == process);
                
                return result;
        }

        public async Task<bool> AddKeyActionLog(Logging logging)
        {
            _entityUnitOfWork.LoggingRepository.Add(logging);
            await _entityUnitOfWork.SaveAsync();
            return true;
        }


    }
}
