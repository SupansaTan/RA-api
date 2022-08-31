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
            return keyactions;
        }

        public List<KeyActionDto> GetKeyActionByLawId(Guid lawId)
        {
            var keyactions = _entityUnitOfWork.KeyActionRepository.GetAll(x => x.LawId == lawId)
                                                                .Select(x => new KeyActionDto()
                                                                {
                                                                    Id = x.Id,
                                                                    KeyReq = x.KeyReq,
                                                                    Standard = x.Standard,
                                                                    Practice = x.Practice,
                                                                    Frequency = x.Frequency,
                                                                    Order = x.Order,
                                                                    LawId = x.LawId,
                                                                }).ToList();
            return keyactions;
        }

        public async Task<Guid> GetTaskKeyActionIdAsync(Guid keyactId, Guid taskId)
        {
            var data = await _entityUnitOfWork.TaskKeyActionRepository.GetSingleAsync(x => x.TaskId == taskId && x.KeyActId == keyactId);
            if (data == null)
            {
                throw new ArgumentException("TaskKeyAction does not exist.");
            }
            else
            {
                return data.Id;
            }
                
        }

        public Guid GetTaskKeyActionId(Guid keyactId, Guid taskId)
        {
            var data = _entityUnitOfWork.TaskKeyActionRepository.GetSingle(x => x.TaskId == taskId && x.KeyActId == keyactId);
            if (data == null)
            {
                throw new ArgumentException("TaskKeyAction does not exist.");
            }
            else
            {
                return data.Id;
            }

        }

        public async Task<KeyAction> AddKeyAction(KeyAction keyaction)
        {
            var result = _entityUnitOfWork.KeyActionRepository.Add(keyaction);
            await _entityUnitOfWork.SaveAsync();
            return keyaction;
        }
    }
}
