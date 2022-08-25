using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RegulationAssessment.Api.Models;
using RegulationAssessment.DataAccess.EntityFramework.Models;
using RegulationAssessment.Logic.UnitOfWork.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegulationAssessment.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : Controller
    {
        private readonly ILogicUnitOfWork _logicUnitOfWork;
        public NotificationController(ILogicUnitOfWork logicUnitOfWork)
        {
            _logicUnitOfWork = logicUnitOfWork;
        }

        [HttpGet("GetNotificationByEmpId")]
        public async Task<ResponseModel<List<NotificationModel>>> GetNotificationByEmpId([FromQuery] Guid empId)
        {
            var response = new ResponseModel<List<NotificationModel>>();
            try
            {
                var result = await _logicUnitOfWork.NotificationService.GetNotificationByEmpId(empId);
                response = new ResponseModel<List<NotificationModel>>
                {
                    Data = result.Select(x => new NotificationModel()
                    {
                        LawTitle = x.LawTitle,
                        Process = x.Process,
                        NotifyDate = x.NotifyDate,
                        Read = x.Read,
                    }).ToList(),
                    Message = "success",
                    Status = 200
                };
            }
            catch (ArgumentException e)
            {
                response = new ResponseModel<List<NotificationModel>>
                {
                    Data = null,
                    Message = e.Message,
                    Status = 400
                };
            }
            catch (Exception e)
            {
                response = new ResponseModel<List<NotificationModel>>
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