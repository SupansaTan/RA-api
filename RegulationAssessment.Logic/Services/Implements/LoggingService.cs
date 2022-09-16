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
using Newtonsoft.Json;

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
                        new ParamCommand { Key = "_taskId", Value = taskId.ToString() },
                        new ParamCommand { Key = "_taskProcess", Value = process.ToString() }
                    );
            return (await _dapperUnitOfWork.RARepository.QueryAsync<LoggingAssessmentDto>(queryGetLog)).ToList();
        }

        public async Task<List<ConsistanceAssessmentDto>> GetConsistanceLogList(Guid taskId)
        {
            var consistanceLogging = await _entityUnitOfWork.LoggingRepository.GetAll(x => x.TaskKeyAct, x => x.TaskKeyAct.KeyAct)
                                                                              .Where(x => x.Process == (int)TaskProcess.Consistance && x.TaskKeyAct.TaskId == taskId)
                                                                              .OrderBy(x => x.TaskKeyAct.KeyAct.Order)
                                                                              .ToListAsync();
            var result = new List<ConsistanceAssessmentDto>();
            foreach (var consistency in consistanceLogging)
            {
                var responsibleData = String.IsNullOrEmpty(consistency.ResponsibleData)
                                      ? null
                                      : JsonConvert.DeserializeObject<ResponsibleDataDto>(consistency.ResponsibleData);
                var personNameList = new List<string>();
                if (responsibleData?.EmployeeId != null)
                {
                    foreach (var person in responsibleData.EmployeeId)
                    {
                        var personItem = await _entityUnitOfWork.EmployeeRepository.GetSingleAsync(x => x.Id == person);
                        personNameList.Add($"{personItem.FirstName} {personItem.LastName}");
                    }
                }

                var log = new ConsistanceAssessmentDto()
                {
                    Status = consistency.Status,
                    Notation = consistency.Notation,
                    Cost = responsibleData?.Cost,
                    ResponsiblePersonList = personNameList,
                    DueDate = responsibleData?.DueDate,
                };
                result.Add(log);
            }
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

    }
}
