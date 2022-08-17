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

        public List<KeyActionDto> GetAllKeyAction()
        {
            var keyactions = _entityUnitOfWork.KeyActionRepository.GetAll()
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

        public Guid GetTaskKeyActionId(Guid keyactId, Guid taskId)
        {
            var data = _entityUnitOfWork.TaskKeyActionRepository.GetAll(x => x.TaskId == taskId  && x.KeyActId == keyactId)
                                                                .Select(x => new TaskKeyActionDto()
                                                                {
                                                                    Id = x.Id,
                                                                    TaskId = x.TaskId,
                                                                    KeyActId = x.KeyActId
                                                                }).ToList();
            return data.First().Id;
        }

    }
}
