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
        public async Task<ResponseModel<List<NotificationListDataModel>>> GetNotificationByEmpId([FromQuery] Guid empId)
        {
            var response = new ResponseModel<List<NotificationListDataModel>>();
            try
            {
                var result = await _logicUnitOfWork.NotificationService.GetNotificationByEmpId(empId);
                var date_ = await _logicUnitOfWork.NotificationService.GetNotificationDateByEmpId(empId);
                response = new ResponseModel<List<NotificationListDataModel>>
                {
                    Data = date_.Select(x => new NotificationListDataModel()
                    {
                        date = x.date,
                        data = result.Select(i => new NotificationModel()
                        {
                            type = i.type,
                            title = i.title,
                            content = i.content,
                            time = i.time,
                            readStatus = i.readStatus,
                        }).ToList()
                    }).ToList(),
                    Message = "success",
                    Status = 200
                };
            }
            catch (ArgumentException e)
            {
                response = new ResponseModel<List<NotificationListDataModel>>
                {
                    Data = null,
                    Message = e.Message,
                    Status = 400
                };
            }
            catch (Exception e)
            {
                response = new ResponseModel<List<NotificationListDataModel>>
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