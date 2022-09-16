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
using Microsoft.EntityFrameworkCore;

namespace RegulationAssessment.Logic.Services.Implements
{
    public class KeyActionService : IKeyActionService
    {
        private readonly IEntityUnitOfWork _entityUnitOfWork;
        private readonly IDapperUnitOfWork _dapperUnitOfWork;

    public KeyActionService(
            IEntityUnitOfWork entityUnitOfWork,
            IDapperUnitOfWork dapperUnitOfWork
            )
        {
            _entityUnitOfWork = entityUnitOfWork;
            _dapperUnitOfWork = dapperUnitOfWork;
        }

        public async Task<List<KeyActionDto>> GetAllKeyAction(Guid taskId)
        {
            var task = await _entityUnitOfWork.TaskRepository.GetSingleAsync(x => x.Id == taskId);
            var keyactions = await _entityUnitOfWork.KeyActionRepository.GetAll(x => x.LawId == task.LawId)
                                                                .Select(x => new KeyActionDto()
                                                                {
                                                                    Id = x.Id,
                                                                    KeyReq = x.KeyReq,
                                                                    Standard = x.Standard,
                                                                    Practice = x.Practice,
                                                                    Frequency = x.Frequency,
                                                                    Order = x.Order,
                                                                    LawId = x.LawId,
                                                                }).OrderBy(x => x.Order).ToListAsync();

            if (task.Process > (int)TaskProcess.ApproveRelevant && task.Process < (int)TaskProcess.Response)
            {
                var relevantLoggingList = await _entityUnitOfWork.LoggingRepository.GetAll(x => x.TaskKeyAct)
                                                                                   .Where(x => x.Process == (int)TaskProcess.Relevant && x.TaskKeyAct.TaskId == taskId && x.Status == true)
                                                                                   .Select(x => x.TaskKeyAct.KeyActId)
                                                                                   .ToListAsync();
                keyactions = keyactions.Where(x => relevantLoggingList.Contains(x.Id)).ToList();
            }
            else if (task.Process > (int)TaskProcess.ApproveConsistance && task.Process < (int)TaskProcess.Done)
            {
                var inconsistanceLoggingList = await _entityUnitOfWork.LoggingRepository.GetAll(x => x.TaskKeyAct)
                                                                                   .Where(x => x.Process == (int)TaskProcess.Consistance && x.TaskKeyAct.TaskId == taskId && x.Status == false)
                                                                                   .Select(x => x.TaskKeyAct.KeyActId)
                                                                                   .ToListAsync();
                keyactions = keyactions.Where(x => inconsistanceLoggingList.Contains(x.Id)).ToList();
            }
            return keyactions;
        }
    }
}
