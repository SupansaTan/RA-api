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
        
        [HttpGet("GetLoggingAssessment")]
        public async Task<ResponseModel<List<LoggingAssessmentModel>>> GetLoggingAssessment([FromQuery] Guid taskId, int process)
        {
            ResponseModel<List<LoggingAssessmentModel>> response;
            try
            {
                var result = await _logicUnitOfWork.LoggingService.GetLogging(taskId, process);
                response = new ResponseModel<List<LoggingAssessmentModel>>
                {
                    Data = result.Select(x => new LoggingAssessmentModel()
                    {
                        Id = x.Id,
                        Process = x.Process,
                        Status = x.Status,
                        Notation = x.Notation,
                        KeyActId = x.KeyActId,
                    }).ToList(),
                    Message = "success",
                    Status = 200
                };
            }
            catch (ArgumentException e)
            {
                response = new ResponseModel<List<LoggingAssessmentModel>>
                {
                    Data = null,
                    Message = e.Message,
                    Status = 400
                };
            }
            catch (Exception e)
            {
                response = new ResponseModel<List<LoggingAssessmentModel>>
                {
                    Data = null,
                    Message = e.Message,
                    Status = 500
                };
            }
            return response;
        }

        [HttpGet("GetConsistanceLogList")]
        public async Task<ResponseModel<List<ConsistanceAssessmentModel>>> GetConsistanceLogList([FromQuery] Guid taskId)
        {
            ResponseModel<List<ConsistanceAssessmentModel>> response;
            try
            {
                var result = await _logicUnitOfWork.LoggingService.GetConsistanceLogList(taskId);
                response = new ResponseModel<List<ConsistanceAssessmentModel>>
                {
                    Data = result.Select(x => new ConsistanceAssessmentModel()
                    {
                        Status = x.Status,
                        Notation = x.Notation,
                        Cost = x.Cost,
                        DueDate = x.DueDate,
                        ResponsiblePersonList = x.ResponsiblePersonList
                    }).ToList(),
                    Message = "success",
                    Status = 200
                };
            }
            catch (ArgumentException e)
            {
                response = new ResponseModel<List<ConsistanceAssessmentModel>>
                {
                    Data = null,
                    Message = e.Message,
                    Status = 400
                };
            }
            catch (Exception e)
            {
                response = new ResponseModel<List<ConsistanceAssessmentModel>>
                {
                    Data = null,
                    Message = e.Message,
                    Status = 500
                };
            }
            return response;
        }

        [HttpGet("GetAllLoggingAssessment")]
        public async Task<ResponseModel<List<LoggingAllHistoryListModel>>> GetAllLoggingAssessment([FromQuery] Guid taskId)
        {
            ResponseModel<List<LoggingAllHistoryListModel>> response;
            try
            {
                var result = await _logicUnitOfWork.LoggingService.GetAllLogging(taskId);
                response = new ResponseModel<List<LoggingAllHistoryListModel>>
                {
                    Data = result.Select(x => new LoggingAllHistoryListModel()
                    {
                        KeyActOrder = x.KeyActOrder,
                        LoggingList = x.LoggingList.Select(x => new LoggingAllHistoryModel()
                        {
                            CreateDate = x.CreateDate,
                            EmployeeName = x.EmployeeName,
                            TaskProcessTitle = x.TaskProcessTitle
                        }).ToList()
                    }).ToList(),
                    Message = "success",
                    Status = 200
                };
            }
            catch (ArgumentException e)
            {
                response = new ResponseModel<List<LoggingAllHistoryListModel>>
                {
                    Data = null,
                    Message = e.Message,
                    Status = 400
                };
            }
            catch (Exception e)
            {
                response = new ResponseModel<List<LoggingAllHistoryListModel>>
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