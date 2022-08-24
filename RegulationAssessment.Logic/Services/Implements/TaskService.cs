using RegulationAssessment.DataAccess.EntityFramework.UnitOfWork.Interface;
using RegulationAssessment.Logic.DomainModel;
using RegulationAssessment.Logic.Services.Interfaces;
using RegulationAssessment.Common.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RegulationAssessment.DataAccess.Dapper.Interface;
using RegulationAssessment.Common.Helper;
using TaskResult = RegulationAssessment.DataAccess.EntityFramework.Models.Task;

namespace RegulationAssessment.Logic.Services.Implements
{
    public class TaskService : ITaskService
    {
        private readonly IEntityUnitOfWork _entityUnitOfWork;
        private readonly IDapperUnitOfWork _dapperUnitOfWork;
        private readonly string QUERY_PATH;

        public TaskService(
            IEntityUnitOfWork entityUnitOfWork,
            IDapperUnitOfWork dapperUnitOfWork
            )
        {
            QUERY_PATH = this.GetType().Name.Split("Service")[0] + "/";
            _entityUnitOfWork = entityUnitOfWork;
            _dapperUnitOfWork = dapperUnitOfWork;
        }

        public List<TaskDto> GetRelevantTaskList()
        {
            return _entityUnitOfWork.TaskRepository.GetAll(x => x.Process == (int)TaskProcess.Relevant)
                                                    .Select(x => new TaskDto()
                                                    {
                                                        Id = x.Id,
                                                        LocationId = x.LocationId,
                                                        LawId = x.LawId,
                                                        Process = x.Process,
                                                        DueDate = x.DueDate,
                                                        CompleteDate = x.CompleteDate.GetValueOrDefault()
                                                    }).ToList();
        }
        public List<TaskDto> GetApproveRelevantTaskList()
        {
            return _entityUnitOfWork.TaskRepository.GetAll(x => x.Process == (int)TaskProcess.ApproveRelevant)
                                                    .Select(x => new TaskDto()
                                                    {
                                                        Id = x.Id,
                                                        LocationId = x.LocationId,
                                                        LawId = x.LawId,
                                                        Process = x.Process,
                                                        DueDate = x.DueDate,
                                                        CompleteDate = x.CompleteDate.GetValueOrDefault()
                                                    }).ToList();
        }
        public List<TaskDto> GetConsistanceTaskList()
        {
            return _entityUnitOfWork.TaskRepository.GetAll(x => x.Process == (int)TaskProcess.Consistance)
                                                    .Select(x => new TaskDto()
                                                    {
                                                        Id = x.Id,
                                                        LocationId = x.LocationId,
                                                        LawId = x.LawId,
                                                        Process = x.Process,
                                                        DueDate = x.DueDate,
                                                        CompleteDate = x.CompleteDate.GetValueOrDefault()
                                                    }).ToList();
        }
        public List<TaskDto> GetApproveConsistanceTaskList()
        {
            return _entityUnitOfWork.TaskRepository.GetAll(x => x.Process == (int)TaskProcess.ApproveConsistance)
                                                    .Select(x => new TaskDto()
                                                    {
                                                        Id = x.Id,
                                                        LocationId = x.LocationId,
                                                        LawId = x.LawId,
                                                        Process = x.Process,
                                                        DueDate = x.DueDate,
                                                        CompleteDate = x.CompleteDate.GetValueOrDefault()
                                                    }).ToList();
        }
        public List<TaskDto> GetResponseTaskList()
        {
            return _entityUnitOfWork.TaskRepository.GetAll(x => x.Process == (int)TaskProcess.Response)
                                                        .Select(x => new TaskDto()
                                                        {
                                                            Id = x.Id,
                                                            LocationId = x.LocationId,
                                                            LawId = x.LawId,
                                                            Process = x.Process,
                                                            DueDate = x.DueDate,
                                                            CompleteDate = x.CompleteDate.GetValueOrDefault()
                                                        }).ToList();
        }
        public List<TaskDto> GetDoneTaskList()
        {
            return _entityUnitOfWork.TaskRepository.GetAll(x => x.Process == (int)TaskProcess.Done)
                                                        .Select(x => new TaskDto()
                                                        {
                                                            Id = x.Id,
                                                            LocationId = x.LocationId,
                                                            LawId = x.LawId,
                                                            Process = x.Process,
                                                            DueDate = x.DueDate,
                                                            CompleteDate = x.CompleteDate.GetValueOrDefault()
                                                        }).ToList();
        }
        public async Task<List<TaskItemDto>> GetTaskListByEmpId(Guid empId)
        {
            var employeeInfo = await _entityUnitOfWork.DutyRepository.GetSingleAsync(x => x.EmpId == empId);
            if (employeeInfo == null)
            {
                throw new ArgumentException("Employee does not exist.");
            }
            else
            {
                var query = QueryService.GetCommand(QUERY_PATH + "getTaskList",
                            new ParamCommand { Key = "_empLocationId", Value = employeeInfo.LocationId.ToString() }
                        );
                return (await _dapperUnitOfWork.RARepository.QueryAsync<TaskItemDto>(query)).Take(5).ToList();
            }
        }

        public async Task<bool> UpdateTask(TaskResult task)
        {
            var taskItem = await _entityUnitOfWork.TaskRepository.GetSingleAsync(x => x.Id == task.Id);
            if (taskItem == null)
            {
                throw new ArgumentException("Task does not exist.");
            }
            else
            {
                taskItem.Process = task.Process;
                taskItem.DueDate = task.DueDate;
                taskItem.CompleteDate = task.CompleteDate;
                _entityUnitOfWork.TaskRepository.Update(taskItem);
                await _entityUnitOfWork.SaveAsync();
                return true;
            }
        }
    }
}
