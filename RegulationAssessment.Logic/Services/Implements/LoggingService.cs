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
using Microsoft.EntityFrameworkCore;

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

        public async Task<List<LoggingAllHistoryListDto>> GetAllLogging(Guid taskId)
        {
            var taskKeyActList = await _entityUnitOfWork.TaskKeyActionRepository.GetAll(x => x.KeyAct)
                                                                                .Where(x => x.TaskId == taskId)
                                                                                .OrderBy(x => x.KeyAct.Order)
                                                                                .ToListAsync();
            List<LoggingAllHistoryListDto> result = new List<LoggingAllHistoryListDto>();
            foreach (var taskKeyAct in taskKeyActList)
            {
                var logging = await _entityUnitOfWork.LoggingRepository.GetAll(x => x.Emp)
                                                                       .Where(x => x.TaskKeyActId == taskKeyAct.Id)
                                                                       .OrderBy(x => x.CreateDate)
                                                                       .ToListAsync();
                List<LoggingAllHistoryDto> historyList = new List<LoggingAllHistoryDto>();
                foreach (var log in logging)
                {
                    var newLog = new LoggingAllHistoryDto()
                    {
                        CreateDate = log.CreateDate,
                        EmployeeName = $"{log.Emp.FirstName} {log.Emp.LastName}",
                        TaskProcessTitle = log.Process == (int)TaskProcess.Relevant
                                           ? "ประเมินความเกี่ยวข้อง"
                                           : log.Process == (int)TaskProcess.Consistance
                                           ? "ประเมินความสอดคล้อง"
                                           : log.Process == (int)TaskProcess.ApproveRelevant
                                           ? "อนุมัติความเกี่ยวข้อง"
                                           : log.Process == (int)TaskProcess.ApproveConsistance
                                           ? "อนุมัติความสอดคล้อง"
                                           : log.Process == (int)TaskProcess.Response
                                           ? "ปฏิบัติให้สอดคล้อง"
                                           : "อนุมัติการปฏิบัติให้สอดคล้อง"
                    };
                    historyList.Add(newLog);
                }

                var keyAct = new LoggingAllHistoryListDto()
                {
                    KeyActOrder = taskKeyAct.KeyAct.Order,
                    LoggingList = historyList
                };
                result.Add(keyAct);
            }
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
