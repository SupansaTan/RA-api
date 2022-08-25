using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RegulationAssessment.Api.Models;
using RegulationAssessment.DataAccess.EntityFramework.Models;
using RegulationAssessment.Logic.UnitOfWork.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        [HttpPut("UpdateTask")]
        public async Task<ResponseModel<bool>> UpdateTask([FromBody]
            Guid id,
            Guid locationId,
            Guid lawId,
            int process,
            DateTime dueDate,
            DateTime? completeDate
        )
        {
            ResponseModel<bool> response;
            try
            {
                var newtask = new Task()
                {
                    Id = id,
                    LocationId = locationId,
                    LawId = lawId,
                    Process = process,
                    DueDate = dueDate,
                    CompleteDate = completeDate ?? null
                };
                var result = await _logicUnitOfWork.TaskService.UpdateTask(newtask);
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
    }
}
