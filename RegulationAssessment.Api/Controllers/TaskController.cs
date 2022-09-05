using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RegulationAssessment.Api.Models;
using RegulationAssessment.DataAccess.EntityFramework.Models;
using RegulationAssessment.Logic.DomainModel;
using RegulationAssessment.Logic.UnitOfWork.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;
using Task = RegulationAssessment.DataAccess.EntityFramework.Models.Task;

namespace RegulationAssessment.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : Controller
    {
        private readonly ILogicUnitOfWork _logicUnitOfWork;
        public TaskController(ILogicUnitOfWork logicUnitOfWork)
        {
            _logicUnitOfWork = logicUnitOfWork;
        }

        [HttpGet("GetRelevantTaskList")]
        public ResponseModel<List<TaskModel>> GetRelevantTaskList()
        {
            ResponseModel<List<TaskModel>> response;
            try
            {
                var result = _logicUnitOfWork.TaskService.GetRelevantTaskList();
                response = new ResponseModel<List<TaskModel>>
                {
                    Data = result.Select(x => new TaskModel()
                    {
                        Id = x.Id,
                        LocationId = x.LocationId,
                        LawId = x.LawId,
                        Process = x.Process,
                        DueDate = x.DueDate,
                        CompleteDate = x.CompleteDate
                    }).ToList(),
                    Message = "success",
                    Status = 200
                };
            }
            catch (ArgumentException e)
            {
                response = new ResponseModel<List<TaskModel>>
                {
                    Data = null,
                    Message = e.Message,
                    Status = 400
                };
            }
            catch (Exception e)
            {
                response = new ResponseModel<List<TaskModel>>
                {
                    Data = null,
                    Message = e.Message,
                    Status = 500
                };
            }
            return response;
        }
        [HttpGet("GetApproveRelevantTaskList")]
        public ResponseModel<List<TaskModel>> GetApproveRelevantTaskList()
        {
            ResponseModel<List<TaskModel>> response;
            try
            {
                var result = _logicUnitOfWork.TaskService.GetApproveRelevantTaskList();
                response = new ResponseModel<List<TaskModel>>
                {
                    Data = result.Select(x => new TaskModel()
                    {
                        Id = x.Id,
                        LocationId = x.LocationId,
                        LawId = x.LawId,
                        Process = x.Process,
                        DueDate = x.DueDate,
                        CompleteDate = x.CompleteDate
                    }).ToList(),
                    Message = "success",
                    Status = 200
                };
            }
            catch (ArgumentException e)
            {
                response = new ResponseModel<List<TaskModel>>
                {
                    Data = null,
                    Message = e.Message,
                    Status = 400
                };
            }
            catch (Exception e)
            {
                response = new ResponseModel<List<TaskModel>>
                {
                    Data = null,
                    Message = e.Message,
                    Status = 500
                };
            }
            return response;
        }
        [HttpGet("GetConsistanceTaskList")]
        public ResponseModel<List<TaskModel>> GetConsistanceTaskList()
        {
            ResponseModel<List<TaskModel>> response;
            try
            {
                var result = _logicUnitOfWork.TaskService.GetConsistanceTaskList();
                response = new ResponseModel<List<TaskModel>>
                {
                    Data = result.Select(x => new TaskModel()
                    {
                        Id = x.Id,
                        LocationId = x.LocationId,
                        LawId = x.LawId,
                        Process = x.Process,
                        DueDate = x.DueDate,
                        CompleteDate = x.CompleteDate
                    }).ToList(),
                    Message = "success",
                    Status = 200
                };
            }
            catch (ArgumentException e)
            {
                response = new ResponseModel<List<TaskModel>>
                {
                    Data = null,
                    Message = e.Message,
                    Status = 400
                };
            }
            catch (Exception e)
            {
                response = new ResponseModel<List<TaskModel>>
                {
                    Data = null,
                    Message = e.Message,
                    Status = 500
                };
            }
            return response;
        }
        [HttpGet("GetApproveConsistanceTaskList")]
        public ResponseModel<List<TaskModel>> GetApproveConsistanceTaskList()
        {
            ResponseModel<List<TaskModel>> response;
            try
            {
                var result = _logicUnitOfWork.TaskService.GetApproveConsistanceTaskList();
                response = new ResponseModel<List<TaskModel>>
                {
                    Data = result.Select(x => new TaskModel()
                    {
                        Id = x.Id,
                        LocationId = x.LocationId,
                        LawId = x.LawId,
                        Process = x.Process,
                        DueDate = x.DueDate,
                        CompleteDate = x.CompleteDate
                    }).ToList(),
                    Message = "success",
                    Status = 200
                };
            }
            catch (ArgumentException e)
            {
                response = new ResponseModel<List<TaskModel>>
                {
                    Data = null,
                    Message = e.Message,
                    Status = 400
                };
            }
            catch (Exception e)
            {
                response = new ResponseModel<List<TaskModel>>
                {
                    Data = null,
                    Message = e.Message,
                    Status = 500
                };
            }
            return response;
        }
        [HttpGet("GetResponseTaskList")]
        public ResponseModel<List<TaskModel>> GetResponseTaskList()
        {
            ResponseModel<List<TaskModel>> response;
            try
            {
                var result = _logicUnitOfWork.TaskService.GetResponseTaskList();
                response = new ResponseModel<List<TaskModel>>
                {
                    Data = result.Select(x => new TaskModel()
                    {
                        Id = x.Id,
                        LocationId = x.LocationId,
                        LawId = x.LawId,
                        Process = x.Process,
                        DueDate = x.DueDate,
                        CompleteDate = x.CompleteDate
                    }).ToList(),
                    Message = "success",
                    Status = 200
                };
            }
            catch (ArgumentException e)
            {
                response = new ResponseModel<List<TaskModel>>
                {
                    Data = null,
                    Message = e.Message,
                    Status = 400
                };
            }
            catch (Exception e)
            {
                response = new ResponseModel<List<TaskModel>>
                {
                    Data = null,
                    Message = e.Message,
                    Status = 500
                };
            }
            return response;
        }
        [HttpGet("GetDoneTaskList")]
        public ResponseModel<List<TaskModel>> GetDoneTaskList()
        {
            ResponseModel<List<TaskModel>> response;
            try
            {
                var result = _logicUnitOfWork.TaskService.GetDoneTaskList();
                response = new ResponseModel<List<TaskModel>>
                {
                    Data = result.Select(x => new TaskModel()
                    {
                        Id = x.Id,
                        LocationId = x.LocationId,
                        LawId = x.LawId,
                        Process = x.Process,
                        DueDate = x.DueDate,
                        CompleteDate = x.CompleteDate
                    }).ToList(),
                    Message = "success",
                    Status = 200
                };
            }
            catch (ArgumentException e)
            {
                response = new ResponseModel<List<TaskModel>>
                {
                    Data = null,
                    Message = e.Message,
                    Status = 400
                };
            }
            catch (Exception e)
            {
                response = new ResponseModel<List<TaskModel>>
                {
                    Data = null,
                    Message = e.Message,
                    Status = 500
                };
            }
            return response;
        }
        [HttpGet("GetTaskListByEmpId")]
        public async Task<ResponseModel<List<TaskItemModel>>> GetTaskListByEmpId([FromQuery] Guid empId)
        {
            var response = new ResponseModel<List<TaskItemModel>>();
            try
            {
                var result = await _logicUnitOfWork.TaskService.GetTaskListByEmpId(empId);
                response = new ResponseModel<List<TaskItemModel>>
                {
                    Data = result.Select(x => new TaskItemModel()
                    {
                        TaskId = x.TaskId,
                        TaskTitle = x.TaskTitle,
                        LocationName = x.LocationName,
                        DueDate = x.DueDate,
                        Process = x.Process,
                        DatetimeStatus = x.DatetimeStatus
                    }).ToList(),
                    Message = "success",
                    Status = 200
                };
            }
            catch (ArgumentException e)
            {
                response = new ResponseModel<List<TaskItemModel>>
                {
                    Data = null,
                    Message = e.Message,
                    Status = 400
                };
            }
            catch (Exception e)
            {
                response = new ResponseModel<List<TaskItemModel>>
                {
                    Data = null,
                    Message = e.Message,
                    Status = 500
                };
            }
            return response;
        }
        [HttpGet("GetTaskListByLocationId")]
        public async Task<ResponseModel<List<TaskListSortByProcessModel>>> GetTaskListByLocationId([FromQuery] Guid locationId, string? keyword = "")
        {
            var response = new ResponseModel<List<TaskListSortByProcessModel>>();
            try
            {
                var result = await _logicUnitOfWork.TaskService.GetTaskListByLocationId(locationId, keyword);
                response = new ResponseModel<List<TaskListSortByProcessModel>>
                {
                    Data = result.Select(x => new TaskListSortByProcessModel()
                    {
                        TaskProcess = x.TaskProcess,
                        TaskList = x.TaskList.Select(y => new TaskItemModel()
                        {
                            TaskId = y.TaskId,
                            TaskTitle = y.TaskTitle,
                            Process = y.Process,
                            DatetimeStatus = y.DatetimeStatus,
                            DueDate = y.DueDate
                        }).ToList()
                    }).ToList(),
                    Message = "success",
                    Status = 200
                };
            }
            catch (ArgumentException e)
            {
                response = new ResponseModel<List<TaskListSortByProcessModel>>
                {
                    Data = null,
                    Message = e.Message,
                    Status = 400
                };
            }
            catch (Exception e)
            {
                response = new ResponseModel<List<TaskListSortByProcessModel>>
                {
                    Data = null,
                    Message = e.Message,
                    Status = 500
                };
            }
            return response;
        }
        [HttpGet("GetTaskDetail")]
        public async Task<ResponseModel<TaskInfoModel>> GetTaskDetail([FromQuery] Guid taskId)
        {
            var response = new ResponseModel<TaskInfoModel>();
            try
            {
                var result = await _logicUnitOfWork.TaskService.GetTaskDetail(taskId);
                response = new ResponseModel<TaskInfoModel>
                {
                    Data = new TaskInfoModel()
                    {
                        TaskId = result.TaskId,
                        TaskTitle = result.TaskTitle,
                        LocationName = result.LocationName,
                        ActType = result.ActType,
                        TotalKeyAct = result.TotalKeyAct,
                        DueDate = result.DueDate,
                        DatetimeStatus = result.DatetimeStatus
                    },
                    Message = "success",
                    Status = 200
                };
            }
            catch (ArgumentException e)
            {
                response = new ResponseModel<TaskInfoModel>
                {
                    Data = null,
                    Message = e.Message,
                    Status = 400
                };
            }
            catch (Exception e)
            {
                response = new ResponseModel<TaskInfoModel>
                {
                    Data = null,
                    Message = e.Message,
                    Status = 500
                };
            }
            return response;
        }
        [HttpPut("UpdateTaskRelevant")]
        public async Task<ResponseModel<bool>> UpdateTaskRelevant([FromBody] TaskAssessmentModel request)
        {
            ResponseModel<bool> response;
            try
            {
                var result = await _logicUnitOfWork.TaskService.UpdateTaskRelevant(new TaskAssessmentDto()
                {
                    TaskId = request.TaskId,
                    EmployeeId = request.EmployeeId,
                    Process = request.Process,
                    KeyActionList = request.KeyActionList.Select(x => new KeyActionAssessmentDto()
                    {
                        KeyActId = x.KeyActId,
                        IsChecked = x.IsChecked,
                        Notation = x.Notation
                    }).ToList()
                });
                response = new ResponseModel<bool>
                {
                    Data = result,
                    Message = "success",
                    Status = 200
                };
            }
            catch (ArgumentException e)
            {
                response = new ResponseModel<bool>
                {
                    Data = false,
                    Message = e.Message,
                    Status = 400
                };
            }
            catch (Exception e)
            {
                response = new ResponseModel<bool>
                {
                    Data = false,
                    Message = e.Message,
                    Status = 500
                };
            }
            return response;
        }
        [HttpPut("UpdateTaskApproveRelevant")]
        public async Task<ResponseModel<bool>> UpdateTaskApproveRelevant([FromBody] TaskAssessmentModel request)
        {
            ResponseModel<bool> response;
            try
            {
                var result = await _logicUnitOfWork.TaskService.UpdateTaskApproveRelevant(new TaskAssessmentDto()
                {
                    TaskId = request.TaskId,
                    EmployeeId = request.EmployeeId,
                    Process = request.Process,
                    KeyActionList = request.KeyActionList.Select(x => new KeyActionAssessmentDto()
                    {
                        KeyActId = x.KeyActId,
                        IsChecked = x.IsChecked,
                        Notation = x.Notation
                    }).ToList()
                });
                response = new ResponseModel<bool>
                {
                    Data = result,
                    Message = "success",
                    Status = 200
                };
            }
            catch (ArgumentException e)
            {
                response = new ResponseModel<bool>
                {
                    Data = false,
                    Message = e.Message,
                    Status = 400
                };
            }
            catch (Exception e)
            {
                response = new ResponseModel<bool>
                {
                    Data = false,
                    Message = e.Message,
                    Status = 500
                };
            }
            return response;
        }
        [HttpPut("UpdateTaskConsistance")]
        public async Task<ResponseModel<bool>> UpdateTaskConsistance([FromBody] TaskAssessmentModel request)
        {
            ResponseModel<bool> response;
            try
            {
                var result = await _logicUnitOfWork.TaskService.UpdateTaskConsistance(new TaskAssessmentDto()
                {
                    TaskId = request.TaskId,
                    EmployeeId = request.EmployeeId,
                    Process = request.Process,
                    KeyActionList = request.KeyActionList.Select(x => new KeyActionAssessmentDto()
                    {
                        KeyActId = x.KeyActId,
                        IsChecked = x.IsChecked,
                        Notation = x.Notation,
                        ResponsePersonId = x.ResponsePersonId,
                        Cost = x.Cost,
                        DueDate = x.DueDate
                    }).ToList()
                });
                response = new ResponseModel<bool>
                {
                    Data = result,
                    Message = "success",
                    Status = 200
                };
            }
            catch (ArgumentException e)
            {
                response = new ResponseModel<bool>
                {
                    Data = false,
                    Message = e.Message,
                    Status = 400
                };
            }
            catch (Exception e)
            {
                response = new ResponseModel<bool>
                {
                    Data = false,
                    Message = e.Message,
                    Status = 500
                };
            }
            return response;
        }
        [HttpPut("UpdateTaskApproveConsistance")]
        public async Task<ResponseModel<bool>> UpdateTaskApproveConsistance([FromBody] TaskAssessmentModel request)
        {
            ResponseModel<bool> response;
            try
            {
                var result = await _logicUnitOfWork.TaskService.UpdateTaskApproveConsistance(new TaskAssessmentDto()
                {
                    TaskId = request.TaskId,
                    EmployeeId = request.EmployeeId,
                    Process = request.Process,
                    KeyActionList = request.KeyActionList.Select(x => new KeyActionAssessmentDto()
                    {
                        KeyActId = x.KeyActId,
                        IsChecked = x.IsChecked,
                        Notation = x.Notation,
                    }).ToList()
                });
                response = new ResponseModel<bool>
                {
                    Data = result,
                    Message = "success",
                    Status = 200
                };
            }
            catch (ArgumentException e)
            {
                response = new ResponseModel<bool>
                {
                    Data = false,
                    Message = e.Message,
                    Status = 400
                };
            }
            catch (Exception e)
            {
                response = new ResponseModel<bool>
                {
                    Data = false,
                    Message = e.Message,
                    Status = 500
                };
            }
            return response;
        }
        [HttpPut("UpdateTaskResponse")]
        public async Task<ResponseModel<bool>> UpdateTaskResponse([FromBody] TaskAssessmentModel request)
        {
            ResponseModel<bool> response;
            try
            {
                var result = await _logicUnitOfWork.TaskService.UpdateTaskResponse(new TaskAssessmentDto()
                {
                    TaskId = request.TaskId,
                    EmployeeId = request.EmployeeId,
                    Process = request.Process,
                    KeyActionList = request.KeyActionList.Select(x => new KeyActionAssessmentDto()
                    {
                        KeyActId = x.KeyActId,
                        IsChecked = x.IsChecked,
                        Notation = x.Notation,
                    }).ToList()
                });
                response = new ResponseModel<bool>
                {
                    Data = result,
                    Message = "success",
                    Status = 200
                };
            }
            catch (ArgumentException e)
            {
                response = new ResponseModel<bool>
                {
                    Data = false,
                    Message = e.Message,
                    Status = 400
                };
            }
            catch (Exception e)
            {
                response = new ResponseModel<bool>
                {
                    Data = false,
                    Message = e.Message,
                    Status = 500
                };
            }
            return response;
        }
        [HttpGet("GetTaskDataById")]
        public async Task<ResponseModel<TaskDataDto>> GetTaskDataById([FromQuery] Guid taskId)
        {
            var response = new ResponseModel<TaskDataDto>();
            try
            {
                var result = await _logicUnitOfWork.TaskService.GetTaskById(taskId);
                response = new ResponseModel<TaskDataDto>
                {
                    Data = result,
                    Message = "success",
                    Status = 200
                };
            }
            catch (ArgumentException e)
            {
                response = new ResponseModel<TaskDataDto>
                {
                    Data = null,
                    Message = e.Message,
                    Status = 400
                };
            }
            catch (Exception e)
            {
                response = new ResponseModel<TaskDataDto>
                {
                    Data = null,
                    Message = e.Message,
                    Status = 500
                };
            }
            return response;
        }
    }
}
