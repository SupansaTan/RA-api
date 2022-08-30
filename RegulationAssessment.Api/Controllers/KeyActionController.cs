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
    public class KeyActionController : Controller
    {
        private readonly ILogicUnitOfWork _logicUnitOfWork;
        public KeyActionController(ILogicUnitOfWork logicUnitOfWork)
        {
            _logicUnitOfWork = logicUnitOfWork;
        }

        [HttpGet("GetAllKeyAction")]
        public async Task<ResponseModel<List<KeyActionModel>>> GetAllKeyAction([FromQuery] Guid taskId)
        {
            ResponseModel<List<KeyActionModel>> response;
            try
            {
                // for only task process: Relevant Assessment
                var result = await _logicUnitOfWork.KeyActionService.GetAllKeyAction(taskId);
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

        [HttpPost("LoggingAssessment/Add")]
        public async Task<ResponseModel<bool>> AddLoggingAssessment([FromBody] RelevantAssessmentModel request)
        {
            ResponseModel<bool> response;
            try
            {
                var assessmentInfo = new RelevantAssessmentModel()
                {
                    EmployeeId = request.EmployeeId,
                    TaskId = request.TaskId,
                    Process = request.Process,
                    KeyActList = request.KeyActList,
                };

                var log = new Logging();
                var result = false;
                assessmentInfo.KeyActList.ForEach(async x =>
                {
                    log.Id = Guid.NewGuid();
                    log.CreateDate = DateTime.Now;
                    log.Notation = x.notation;
                    log.Process = assessmentInfo.Process;
                    log.Status = x.isRelated;
                    log.TaskKeyActId = _logicUnitOfWork.KeyActionService.GetTaskKeyActionId(x.keyActId, assessmentInfo.TaskId);
                    log.EmpId = assessmentInfo.EmployeeId;
                    result = await _logicUnitOfWork.LoggingService.AddKeyActionLog(log);
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

        [HttpPost("Responsibility/Add")]
        public ResponseModel<Responsibility> AddResponsibility(
            int cost,
            bool status,
            Guid taskkeyactId,
            Guid empId
        )
        {
            ResponseModel<Responsibility> response;
            try
            {
                var resp = new Responsibility()
                {
                    Id = Guid.NewGuid(),
                    DueDate = DateTime.Now.AddDays(7),
                    Cost = cost,
                    Status = status,
                    TaskKeyActId = taskkeyactId,
                    EmpId = empId
                };
                var result = _logicUnitOfWork.ResponsibilityService.AddResponsibility(resp);
                response = new ResponseModel<Responsibility>
                {
                    Data = resp,
                    Message = "success",
                    Status = 200
                };
            }
            catch (ArgumentException e)
            {
                response = new ResponseModel<Responsibility>
                {
                    Data = null,
                    Message = e.Message,
                    Status = 400
                };
            }
            catch (Exception e)
            {
                response = new ResponseModel<Responsibility>
                {
                    Data = null,
                    Message = e.Message,
                    Status = 500
                };
            }
            return response;
        }

        [HttpPost("Add")]
        public ResponseModel<KeyAction> AddKeyAction(
            string keyReq,
            string standard,
            string practice,
            string frequency,
            int order,
            Guid lawId
        )
        {
            ResponseModel<KeyAction> response;
            try
            {
                var newkeyact = new KeyAction()
                {
                    Id = Guid.NewGuid(),
                    KeyReq = keyReq,
                    Standard = standard,
                    Practice = practice,
                    Frequency = frequency,
                    Order = order,
                    LawId = lawId
                };
                var result = _logicUnitOfWork.KeyActionService.AddKeyAction(newkeyact);
                response = new ResponseModel<KeyAction>
                {
                    Data = newkeyact,
                    Message = "success",
                    Status = 200
                };
            }
            catch (ArgumentException e)
            {
                response = new ResponseModel<KeyAction>
                {
                    Data = null,
                    Message = e.Message,
                    Status = 400
                };
            }
            catch (Exception e)
            {
                response = new ResponseModel<KeyAction>
                {
                    Data = null,
                    Message = e.Message,
                    Status = 500
                };
            }
            return response;
        }

        [HttpGet("GetTaskKeyActionId")]
        public ResponseModel<Guid> GetTaskKeyActionId(Guid keyactId, Guid taskId)
        {
            ResponseModel<Guid> response;
            try
            {
                var taskkeyactId = _logicUnitOfWork.KeyActionService.GetTaskKeyActionId(keyactId, taskId);
                response = new ResponseModel<Guid>
                {
                    Data = taskkeyactId,
                    Message = "success",
                    Status = 200
                };
            }
            catch (ArgumentException e)
            {
                response = new ResponseModel<Guid>
                {
                    Data = Guid.NewGuid(),
                    Message = e.Message,
                    Status = 400
                };
            }
            catch (Exception e)
            {
                response = new ResponseModel<Guid>
                {
                    Data = Guid.NewGuid(),
                    Message = e.Message,
                    Status = 500
                };
            }
            return response;
        }

    }
}