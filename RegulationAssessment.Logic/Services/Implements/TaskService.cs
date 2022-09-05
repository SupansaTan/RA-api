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
using RegulationAssessment.DataAccess.EntityFramework.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

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
                return (await _dapperUnitOfWork.RARepository.QueryAsync<TaskItemDto>(query)).Skip(0).Take(5).ToList();
            }
        }
        public async Task<List<TaskListSortByProcessDto>> GetTaskListByLocationId(Guid locationId, string searchTerms)
        {
            var location = await _entityUnitOfWork.LocationRepository.GetSingleAsync(x => x.Id == locationId);
            if (location == null)
            {
                throw new ArgumentException("Location does not exist.");
            }
            else
            {
                string keyword = "";
                if (!string.IsNullOrEmpty(searchTerms))
                {
                    var keywords = searchTerms.Split();
                    keywords = keywords.Select(x => x = $"%{x.ToLower()}%").ToArray();
                    keyword = string.Join(" ", keywords);
                }

                var query = QueryService.GetCommand(QUERY_PATH + "getTaskListByLocationId",
                            new ParamCommand { Key = "_locationId", Value = locationId.ToString() },
                            new ParamCommand { Key = "_keyword", Value = keyword }
                        );
                var taskList = (await _dapperUnitOfWork.RARepository.QueryAsync<TaskItemDto>(query)).ToList();

                List<TaskListSortByProcessDto> result = new List<TaskListSortByProcessDto>();
                var currentTaskProcess = 0;
                foreach (var task in taskList)
                {
                    if (currentTaskProcess != (int)task.Process)
                    {
                        var taskItem = new TaskListSortByProcessDto()
                        {
                            TaskProcess = (TaskProcess)task.Process,
                            TaskList = taskList.FindAll(x => x.Process == task.Process).ToList()
                        };
                        currentTaskProcess = (int)task.Process;
                        result.Add(taskItem);
                    }
                }
                return result;
            }
        }
        public async Task<bool> UpdateTaskRelevant(TaskAssessmentDto model)
        {
            var taskItem = await _entityUnitOfWork.TaskRepository.GetSingleAsync(x => x.Id == model.TaskId);
            if (taskItem == null)
            {
                throw new ArgumentException("Task does not exist.");
            }
            else
            {
                List<TaskKeyAct> taskKeyActList = new List<TaskKeyAct>();
                List<Logging> loggingList = new List<Logging>();
                List<Notification> notificationList = new List<Notification>();
                TaskKeyAct taskKeyAct;

                // add log & task key act
                foreach (var keyAct in model.KeyActionList)
                {
                    var taskKeyActItem = await _entityUnitOfWork.TaskKeyActionRepository.GetSingleAsync(x => x.TaskId == model.TaskId && x.KeyActId == keyAct.KeyActId);

                    if (taskKeyActItem == null)
                    {
                        taskKeyAct = new TaskKeyAct()
                        {
                            Id = Guid.NewGuid(),
                            TaskId = model.TaskId,
                            KeyActId = keyAct.KeyActId
                        };
                        taskKeyActList.Add(taskKeyAct);
                    }
                    else
                    {
                        taskKeyAct = taskKeyActItem;
                    }

                    var log = new Logging()
                    {
                        Id = Guid.NewGuid(),
                        CreateDate = DateTime.UtcNow,
                        Notation = keyAct.Notation,
                        Process = (int)model.Process,
                        Status = keyAct.IsChecked,
                        TaskKeyActId = taskKeyAct.Id,
                        EmpId = model.EmployeeId
                    };
                    loggingList.Add(log);
                }
                
                // add notification
                var employeeList = await _entityUnitOfWork.DutyRepository.GetAll(x => x.Role)
                                                                         .Where(x => x.Role.Name == "Approver" && x.LocationId == taskItem.LocationId)
                                                                         .ToListAsync();
                foreach (var employee in employeeList)
                {
                    var noti = new Notification()
                    {
                        Id = Guid.NewGuid(),
                        TaskId = model.TaskId,
                        EmpId = employee.Id,
                        NotifyDate = DateTime.UtcNow,
                        Read = false,
                        Process = (int)TaskProcess.ApproveRelevant
                    };
                    notificationList.Add(noti);
                }

                if (!taskKeyActList.Any())
                {
                    _entityUnitOfWork.TaskKeyActionRepository.AddRange(taskKeyActList);
                }

                // update task process
                taskItem.Process = (int)TaskProcess.ApproveRelevant;
                taskItem.DueDate = DateTime.UtcNow.AddDays(7);
                _entityUnitOfWork.TaskRepository.Update(taskItem);
                _entityUnitOfWork.LoggingRepository.AddRange(loggingList);
                _entityUnitOfWork.NotificationRepository.AddRange(notificationList);
                await _entityUnitOfWork.SaveAsync();
                return true;
            }
        }
        public async Task<bool> UpdateTaskApproveRelevant(TaskAssessmentDto model)
        {
            var taskItem = await _entityUnitOfWork.TaskRepository.GetSingleAsync(x => x.Id == model.TaskId);
            if (taskItem == null)
            {
                throw new ArgumentException("Task does not exist.");
            }
            else
            {
                List<TaskKeyAct> taskKeyActList = new List<TaskKeyAct>();
                List<Logging> loggingList = new List<Logging>();
                List<Notification> notificationList = new List<Notification>();
                TaskKeyAct taskKeyAct;

                // add log & task key act
                foreach (var keyAct in model.KeyActionList)
                {
                    var taskKeyActItem = await _entityUnitOfWork.TaskKeyActionRepository.GetSingleAsync(x => x.TaskId == model.TaskId && x.KeyActId == keyAct.KeyActId);
                    if (taskKeyActItem == null)
                    {
                        taskKeyAct = new TaskKeyAct()
                        {
                            Id = Guid.NewGuid(),
                            TaskId = model.TaskId,
                            KeyActId = keyAct.KeyActId
                        };
                        taskKeyActList.Add(taskKeyAct);
                    }
                    else
                    {
                        taskKeyAct = taskKeyActItem;
                    }

                    var log = new Logging()
                    {
                        Id = Guid.NewGuid(),
                        CreateDate = DateTime.UtcNow,
                        Notation = keyAct.Notation,
                        Process = (int)model.Process,
                        Status = keyAct.IsChecked,
                        TaskKeyActId = taskKeyAct.Id,
                        EmpId = model.EmployeeId
                    };
                    loggingList.Add(log);
                }

                if (model.KeyActionList.Any(x => x.IsChecked == false))
                {
                    // approve all key action --> next process
                    var employeeList = await _entityUnitOfWork.DutyRepository.GetAll(x => x.Role)
                                                                             .Where(x => (x.Role.Name == "BU" || x.Role.Name == "Approver") && x.LocationId == taskItem.LocationId)
                                                                             .ToListAsync();
                    // add notification
                    foreach (var employee in employeeList)
                    {
                        var noti = new Notification()
                        {
                            Id = Guid.NewGuid(),
                            TaskId = model.TaskId,
                            EmpId = employee.Id,
                            NotifyDate = DateTime.UtcNow,
                            Read = false,
                            Process = (int)TaskProcess.Consistance
                        };
                        notificationList.Add(noti);
                    }

                    // update task process
                    taskItem.Process = (int)TaskProcess.Consistance;
                }
                else
                {
                    // disapprove some key action --> re-evaluate the relevance
                    var employeeList = await _entityUnitOfWork.DutyRepository.GetAll(x => x.Role)
                                                                             .Where(x => x.Role.Name == "BU" && x.LocationId == taskItem.LocationId)
                                                                             .ToListAsync();
                    // add notification
                    foreach (var employee in employeeList)
                    {
                        var noti = new Notification()
                        {
                            Id = Guid.NewGuid(),
                            TaskId = model.TaskId,
                            EmpId = employee.Id,
                            NotifyDate = DateTime.UtcNow,
                            Read = false,
                            Process = (int)TaskProcess.Relevant
                        };
                        notificationList.Add(noti);
                    }

                    // update task process
                    taskItem.Process = (int)TaskProcess.Relevant;
                }

                if (!taskKeyActList.Any())
                {
                    _entityUnitOfWork.TaskKeyActionRepository.AddRange(taskKeyActList);
                }

                taskItem.DueDate = DateTime.UtcNow.AddDays(7);
                _entityUnitOfWork.TaskRepository.Update(taskItem);
                _entityUnitOfWork.LoggingRepository.AddRange(loggingList);
                _entityUnitOfWork.NotificationRepository.AddRange(notificationList);
                await _entityUnitOfWork.SaveAsync();
                return true;
            }
        }
        public async Task<bool> UpdateTaskConsistance(TaskAssessmentDto model)
        {
            var taskItem = await _entityUnitOfWork.TaskRepository.GetSingleAsync(x => x.Id == model.TaskId);
            if (taskItem == null)
            {
                throw new ArgumentException("Task does not exist.");
            }
            else
            {
                List<TaskKeyAct> taskKeyActList = new List<TaskKeyAct>();
                List<Logging> loggingList = new List<Logging>();
                List<Notification> notificationList = new List<Notification>();
                TaskKeyAct taskKeyAct;

                foreach (var keyAct in model.KeyActionList)
                {
                    var taskKeyActItem = await _entityUnitOfWork.TaskKeyActionRepository.GetSingleAsync(x => x.TaskId == model.TaskId && x.KeyActId == keyAct.KeyActId);
                    if (taskKeyActItem == null)
                    {
                        taskKeyAct = new TaskKeyAct()
                        {
                            Id = Guid.NewGuid(),
                            TaskId = model.TaskId,
                            KeyActId = keyAct.KeyActId
                        };
                        taskKeyActList.Add(taskKeyAct);
                    }
                    else
                    {
                        taskKeyAct = taskKeyActItem;
                    }

                    // add log
                    var log = new Logging()
                    {
                        Id = Guid.NewGuid(),
                        CreateDate = DateTime.UtcNow,
                        Notation = keyAct.Notation,
                        Process = (int)model.Process,
                        Status = keyAct.IsChecked,
                        TaskKeyActId = taskKeyAct.Id,
                        EmpId = model.EmployeeId,
                        ResponsibleData = keyAct.IsChecked ? null : JsonConvert.SerializeObject(new ResponsibleDataDto()
                        {
                            EmployeeId = keyAct.ResponsePersonId,
                            Cost = keyAct.Cost ?? 0,
                            DueDate = keyAct.DueDate ?? DateTime.UtcNow.AddDays(7)
                        }),
                    };
                    loggingList.Add(log);
                }

                // add notification
                var employeeList = await _entityUnitOfWork.DutyRepository.GetAll(x => x.Role)
                                                                         .Where(x => x.Role.Name == "Approver" && x.LocationId == taskItem.LocationId)
                                                                         .ToListAsync();
                foreach (var employee in employeeList)
                {
                    var noti = new Notification()
                    {
                        Id = Guid.NewGuid(),
                        TaskId = model.TaskId,
                        EmpId = employee.Id,
                        NotifyDate = DateTime.UtcNow,
                        Read = false,
                        Process = (int)TaskProcess.ApproveConsistance
                    };
                    notificationList.Add(noti);
                }

                // update task process
                taskItem.Process = (int)TaskProcess.ApproveConsistance;
                taskItem.DueDate = DateTime.UtcNow.AddDays(7);
                _entityUnitOfWork.TaskRepository.Update(taskItem);
                _entityUnitOfWork.TaskKeyActionRepository.AddRange(taskKeyActList);
                _entityUnitOfWork.LoggingRepository.AddRange(loggingList);
                _entityUnitOfWork.NotificationRepository.AddRange(notificationList);
                await _entityUnitOfWork.SaveAsync();
                return true;
            }
        }
        public async Task<bool> UpdateTaskApproveConsistance(TaskAssessmentDto model)
        {
            var taskItem = await _entityUnitOfWork.TaskRepository.GetSingleAsync(x => x.Id == model.TaskId);
            if (taskItem == null)
            {
                throw new ArgumentException("Task does not exist.");
            }
            else
            {
                List<TaskKeyAct> taskKeyActList = new List<TaskKeyAct>();
                List<Logging> loggingList = new List<Logging>();
                List<Notification> notificationList = new List<Notification>();
                List<Responsibility> responsibleList = new List<Responsibility>();
                TaskKeyAct taskKeyAct;

                foreach (var keyAct in model.KeyActionList)
                {
                    var taskKeyActItem = await _entityUnitOfWork.TaskKeyActionRepository.GetSingleAsync(x => x.TaskId == model.TaskId && x.KeyActId == keyAct.KeyActId);
                    if (taskKeyActItem == null)
                    {
                        taskKeyAct = new TaskKeyAct()
                        {
                            Id = Guid.NewGuid(),
                            TaskId = model.TaskId,
                            KeyActId = keyAct.KeyActId
                        };
                        taskKeyActList.Add(taskKeyAct);
                    }
                    else
                    {
                        taskKeyAct = taskKeyActItem;
                    }

                    // add log
                    var log = new Logging()
                    {
                        Id = Guid.NewGuid(),
                        CreateDate = DateTime.UtcNow,
                        Notation = keyAct.Notation,
                        Process = (int)model.Process,
                        Status = keyAct.IsChecked,
                        TaskKeyActId = taskKeyAct.Id,
                        EmpId = model.EmployeeId
                    };
                    loggingList.Add(log);
                }

                if (model.KeyActionList.Any(x => x.IsChecked == false))
                {
                    // approve all key action --> next process
                    var consistanceLog = await _entityUnitOfWork.LoggingRepository.GetAll(x => x.TaskKeyAct)
                                                                                  .Where(x => x.Process == (int)TaskProcess.Consistance && 
                                                                                              x.TaskKeyAct.TaskId == model.TaskId)
                                                                                  .ToListAsync();
                    if (consistanceLog.Any(x => x.Status == false))
                    {
                        // all key act are consistent
                        taskItem.Process = (int)TaskProcess.Done;
                    }
                    else
                    {
                        var inconsistentList = consistanceLog.Where(x => x.Status == false);
                        foreach (var keyAct in inconsistentList)
                        {
                            var responsibleData = JsonConvert.DeserializeObject<ResponsibleDataDto>(keyAct.ResponsibleData);

                            foreach (var person in responsibleData.EmployeeId)
                            {
                                var responsePerson = new Responsibility()
                                {
                                    Id = Guid.NewGuid(),
                                    EmpId = person,
                                    Cost = responsibleData.Cost,
                                    DueDate = responsibleData.DueDate,
                                    TaskKeyActId = keyAct.TaskKeyActId,
                                    Status = false
                                };
                                responsibleList.Add(responsePerson);

                                var noti = new Notification()
                                {
                                    Id = Guid.NewGuid(),
                                    TaskId = model.TaskId,
                                    EmpId = person,
                                    NotifyDate = DateTime.UtcNow,
                                    Read = false,
                                    Process = (int)TaskProcess.Response
                                };
                                notificationList.Add(noti);
                            }
                        }
                        _entityUnitOfWork.ResponsibilityRepository.AddRange(responsibleList);
                    }
                }
                else
                {
                    // disapprove some key action --> re-evaluate the consistance
                    taskItem.Process = (int)TaskProcess.Consistance;

                    // add notification
                    var employeeList = await _entityUnitOfWork.DutyRepository.GetAll(x => x.Role)
                                                                             .Where(x => (x.Role.Name == "Approver" || x.Role.Name == "BU") && x.LocationId == taskItem.LocationId)
                                                                             .ToListAsync();
                    foreach (var employee in employeeList)
                    {
                        var noti = new Notification()
                        {
                            Id = Guid.NewGuid(),
                            TaskId = model.TaskId,
                            EmpId = employee.Id,
                            NotifyDate = DateTime.UtcNow,
                            Read = false,
                            Process = (int)TaskProcess.Consistance
                        };
                        notificationList.Add(noti);
                    }
                }

                if (!taskKeyActList.Any())
                {
                    _entityUnitOfWork.TaskKeyActionRepository.AddRange(taskKeyActList);
                }

                taskItem.DueDate = DateTime.UtcNow.AddDays(7);
                _entityUnitOfWork.TaskRepository.Update(taskItem);
                _entityUnitOfWork.LoggingRepository.AddRange(loggingList);
                _entityUnitOfWork.NotificationRepository.AddRange(notificationList);
                await _entityUnitOfWork.SaveAsync();
                return true;
            }
        }
        public async Task<TaskDataDto> GetTaskById(Guid taskId)
        {
            var taskinfo = await _entityUnitOfWork.TaskRepository.GetSingleAsync(x => x.Id == taskId);
            if (taskinfo == null)
            {
                throw new ArgumentException("Task does not exist.");
            }
            else
            {
                var query = QueryService.GetCommand(QUERY_PATH + "getTaskDataById",
                            new ParamCommand { Key = "_taskId", Value = taskinfo.Id.ToString() }
                        );
                return (await _dapperUnitOfWork.RARepository.QueryAsync<TaskDataDto>(query)).First();
            }
        }
        public async Task<TaskInfoDto> GetTaskDetail(Guid taskId)
        {
            var task = await _entityUnitOfWork.TaskRepository.GetSingleAsync(x => x.Id == taskId,
                                                                             x => x.Location,
                                                                             x => x.Law,
                                                                             x => x.Law.KeyActions);
            if (task == null)
            {
                throw new ArgumentException("Task does not exist.");
            }
            else
            {
                var now = DateTime.UtcNow;
                return new TaskInfoDto()
                {
                    TaskId = task.Id,
                    TaskTitle = task.Law.Title,
                    DueDate = task.DueDate,
                    LocationName = task.Location.Name,
                    ActType = task.Law.ActType,
                    TotalKeyAct = task.Law.KeyActions.Count,
                    DatetimeStatus = task.DueDate < now
                                     ? TaskTimeStatus.Remain
                                     : (task.DueDate == DateTime.Today) && (task.DueDate >= now)
                                     ? TaskTimeStatus.Today
                                     : TaskTimeStatus.Overdue
                };
            }
        }
    }
}
    