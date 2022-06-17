using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RegulationAssessment.Api.Models;
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
        [HttpGet("GetTaskList")]
        public async Task<ResponseModel<List<TaskModel>>> GetTaskList()
        {
            ResponseModel<List<TaskModel>> response;
            response = new ResponseModel<List<TaskModel>>
            {
                Data = null,
                Message = "success",
                Status = 200
            };
            return response;
        }
    }
}
