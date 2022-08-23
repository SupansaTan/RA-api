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
                        DueDate = x.DueDate
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
        [HttpPut("Task/{id}")]
        public ResponseModel<Task> AddLoggingAssessment(
            Guid id,
            Guid locationId,
            Guid lawId,
            int process,
            DateTime dueDate,
            DateTime? completeDate
        )
        {
            ResponseModel<Task> response;
            try
            {
                var newtask = new Task()
                {
                    Id = id,
                    LocationId = locationId,
                    LawId = lawId,
                    Process = process,
                    DueDate = dueDate,
                    CompleteDate = completeDate==null? null : completeDate
                };
                var result = _logicUnitOfWork.TaskService.UpdateTask(newtask);
                response = new ResponseModel<Task>
                {
                    Data = newtask,
                    Message = "success",
                    Status = 200
                };
            }
            catch (ArgumentException e)
            {
                response = new ResponseModel<Task>
                {
                    Data = null,
                    Message = e.Message,
                    Status = 400
                };
            }
            catch (Exception e)
            {
                response = new ResponseModel<Task>
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
