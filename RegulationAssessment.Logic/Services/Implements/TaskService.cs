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
                                                            LawId = x.LawId,
                                                            Process = x.Process,
                                                            DueDate = x.DueDate,
                                                            CompleteDate = x.CompleteDate == null? new DateTime() : x.CompleteDate
                                                        }).ToList();
            return tasks;
        }
        public List<TaskDto> GetApproveRelevantTaskList()
        {
            var tasks = _entityUnitOfWork.TaskRepository.GetAll(x => x.Process == (int)TaskProcess.ApproveRelevant)
                                                        .Select(x => new TaskDto()
                                                        {
                                                            Id = x.Id,
                                                            LocationId = x.LocationId,
                                                            LawId = x.LawId,
                                                            Process = x.Process,
                                                            DueDate = x.DueDate,
                                                            CompleteDate = x.CompleteDate == null? new DateTime() : x.CompleteDate
                                                        }).ToList();
            return tasks;
        }
        public List<TaskDto> GetConsistanceTaskList()
        {
            var tasks = _entityUnitOfWork.TaskRepository.GetAll(x => x.Process == (int)TaskProcess.Consistance)
                                                        .Select(x => new TaskDto()
                                                        {
                                                            Id = x.Id,
                                                            LocationId = x.LocationId,
                                                            LawId = x.LawId,
                                                            Process = x.Process,
                                                            DueDate = x.DueDate,
                                                            CompleteDate = x.CompleteDate == null? new DateTime() : x.CompleteDate
                                                        }).ToList();
            return tasks;
        }
        public List<TaskDto> GetApproveConsistanceTaskList()
        {
            var tasks = _entityUnitOfWork.TaskRepository.GetAll(x => x.Process == (int)TaskProcess.ApproveConsistance)
                                                        .Select(x => new TaskDto()
                                                        {
                                                            Id = x.Id,
                                                            LocationId = x.LocationId,
                                                            LawId = x.LawId,
                                                            Process = x.Process,
                                                            DueDate = x.DueDate,
                                                            CompleteDate = x.CompleteDate == null? new DateTime() : x.CompleteDate
                                                        }).ToList();
            return tasks;
        }
        public List<TaskDto> GetResponseTaskList()
        {
            var tasks = _entityUnitOfWork.TaskRepository.GetAll(x => x.Process == (int)TaskProcess.Response)
                                                        .Select(x => new TaskDto()
                                                        {
                                                            Id = x.Id,
                                                            LocationId = x.LocationId,
                                                            LawId = x.LawId,
                                                            Process = x.Process,
                                                            DueDate = x.DueDate,
                                                            CompleteDate = x.CompleteDate == null? new DateTime() : x.CompleteDate
                                                        }).ToList();
            return tasks;
        }
        public List<TaskDto> GetDoneTaskList()
        {
            var tasks = _entityUnitOfWork.TaskRepository.GetAll(x => x.Process == (int)TaskProcess.Done)
                                                        .Select(x => new TaskDto()
                                                        {
                                                            Id = x.Id,
                                                            LocationId = x.LocationId,
                                                            LawId = x.LawId,
                                                            Process = x.Process,
                                                            DueDate = x.DueDate,
                                                            CompleteDate = x.CompleteDate == null? new DateTime() : x.CompleteDate
                                                        }).ToList();
            return tasks;
        }
    }
}
