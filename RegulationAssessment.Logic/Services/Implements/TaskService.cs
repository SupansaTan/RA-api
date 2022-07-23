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
    public class TaskService : ITaskService
    {
        private readonly IEntityUnitOfWork _entityUnitOfWork;

        public TaskService(IEntityUnitOfWork entityUnitOfWork)
        {
            _entityUnitOfWork = entityUnitOfWork;
        }

        public List<TaskDto> GetRelevantTaskList()
        {
            var tasks = _entityUnitOfWork.TaskRepository.GetAll(x => x.Process == (int)TaskProcess.Relevant)
                                                        .Select(x => new TaskDto()
                                                        {
                                                            Id = x.Id,
                                                            LocationId = x.LocationId,
                                                            Notation = x.Notation,
                                                            Process = x.Process,
                                                            Status = x.Status.GetValueOrDefault(),
                                                            DueDate = x.DueDate,
                                                            CompleteDate = x.CompleteDate
                                                        }).ToList();
            return tasks;
        }
    }
}
