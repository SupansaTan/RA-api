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
using Task = RegulationAssessment.DataAccess.EntityFramework.Models.Task;

namespace RegulationAssessment.Logic.Services.Implements
{
    public class LoggingService : ILoggingService
    {
        private readonly IEntityUnitOfWork _entityUnitOfWork;
        private readonly IDapperUnitOfWork _dapperUnitOfWork;

    public LoggingService(
            IEntityUnitOfWork entityUnitOfWork,
            IDapperUnitOfWork dapperUnitOfWork
            )
        {
            _entityUnitOfWork = entityUnitOfWork;
            _dapperUnitOfWork = dapperUnitOfWork;
        }

        public List<LoggingDto> GetLoggingByTaskKeyactId(Guid taskkeyactId)
        {
            var Logs = _entityUnitOfWork.LoggingRepository.GetAll(x => x.TaskKeyActId == taskkeyactId)
                                                                .Select(x => new LoggingDto()
                                                                {
                                                                    Id = x.Id,
                                                                    CreateDate = x.CreateDate,
                                                                    Notation = x.Notation,
                                                                    Process = x.Process,
                                                                    Status = x.Status,
                                                                    TaskKeyActId = x.TaskKeyActId,
                                                                    RespId = x.RespId,
                                                                    EmpId = x.EmpId
                                                                }).ToList();
            return Logs;
        }

        public async Task<bool> AddKeyActionLog(Logging logging)
        {
            _entityUnitOfWork.LoggingRepository.Add(logging);
            await _entityUnitOfWork.SaveAsync();
            return true;
        }


    }
}
