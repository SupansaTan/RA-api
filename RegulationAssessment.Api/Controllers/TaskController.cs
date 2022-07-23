using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RegulationAssessment.Api.Models;
using RegulationAssessment.Logic.UnitOfWork.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
                        Notation = x.Notation,
                        Process = x.Process,
                        Status = x.Status,
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
    }
}
