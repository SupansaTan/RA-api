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
    public class KeyActionController : Controller
    {
        private readonly ILogicUnitOfWork _logicUnitOfWork;
        public KeyActionController(ILogicUnitOfWork logicUnitOfWork)
        {
            _logicUnitOfWork = logicUnitOfWork;
        }

        [HttpGet("GetAllKeyAction")]
        public ResponseModel<List<KeyActionModel>> GetAllKeyAction()
        {
            ResponseModel<List<KeyActionModel>> response;
            try
            {
                var result = _logicUnitOfWork.KeyActionService.GetAllKeyAction();
                response = new ResponseModel<List<KeyActionModel>>
                {
                    Data = result.Select(x => new KeyActionModel()
                    {
                        Id = x.Id,
                        KeyReq = x.KeyReq,
                        Standard = x.Standard,
                        Practice = x.Practice,
                        Frequency = x.Frequency,
                        Order = x.Order,
                        LawId = x.LawId,
                    }).ToList(),
                    Message = "success",
                    Status = 200
                };
            }
            catch (ArgumentException e)
            {
                response = new ResponseModel<List<KeyActionModel>>
                {
                    Data = null,
                    Message = e.Message,
                    Status = 400
                };
            }
            catch (Exception e)
            {
                response = new ResponseModel<List<KeyActionModel>>
                {
                    Data = null,
                    Message = e.Message,
                    Status = 500
                };
            }
            return response;
        }

        [HttpGet("GetKeyActionByLawId")]
        public ResponseModel<List<KeyActionModel>> GetKeyActionByLawId(Guid lawId)
        {
            ResponseModel<List<KeyActionModel>> response;
            try
            {
                var result = _logicUnitOfWork.KeyActionService.GetKeyActionByLawId(lawId);
                response = new ResponseModel<List<KeyActionModel>>
                {
                    Data = result.Select(x => new KeyActionModel()
                    {
                        Id = x.Id,
                        KeyReq = x.KeyReq,
                        Standard = x.Standard,
                        Practice = x.Practice,
                        Frequency = x.Frequency,
                        Order = x.Order,
                        LawId = x.LawId,
                    }).ToList(),
                    Message = "success",
                    Status = 200
                };
            }
            catch (ArgumentException e)
            {
                response = new ResponseModel<List<KeyActionModel>>
                {
                    Data = null,
                    Message = e.Message,
                    Status = 400
                };
            }
            catch (Exception e)
            {
                response = new ResponseModel<List<KeyActionModel>>
                {
                    Data = null,
                    Message = e.Message,
                    Status = 500
                };
            }
            return response;
        }

        [HttpGet("GetLoggingAssessment")]
        public ResponseModel<List<LoggingModel>> GetLoggingAssessment(Guid keyactId, Guid taskId)
        {
            ResponseModel<List<LoggingModel>> response;
            try
            {
                var taskkeyactId = _logicUnitOfWork.KeyActionService.GetTaskKeyActionId(keyactId, taskId);
                var result = _logicUnitOfWork.LoggingService.GetLoggingByTaskKeyactId(taskkeyactId);
                response = new ResponseModel<List<LoggingModel>>
                {
                    Data = result.Select(x => new LoggingModel()
                    {
                        Id = x.Id,
                        CreateDate = x.CreateDate,
                        Notation = x.Notation,
                        Process = x.Process,
                        Status = x.Status,
                        TaskKeyActId = x.TaskKeyActId,
                        RespId = x.RespId,
                        EmpId = x.EmpId
                    }).ToList(),
                    Message = "success",
                    Status = 200
                };
            }
            catch (ArgumentException e)
            {
                response = new ResponseModel<List<LoggingModel>>
                {
                    Data = null,
                    Message = e.Message,
                    Status = 400
                };
            }
            catch (Exception e)
            {
                response = new ResponseModel<List<LoggingModel>>
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