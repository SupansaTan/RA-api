using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RegulationAssessment.Api.Models;
using RegulationAssessment.DataAccess.EntityFramework.Models;
using RegulationAssessment.Logic.DomainModel;
using RegulationAssessment.Logic.UnitOfWork.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegulationAssessment.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LawController : ControllerBase
    {
        private readonly ILogicUnitOfWork _logicUnitOfWork;
        public LawController(ILogicUnitOfWork logicUnitOfWork)
        {
            _logicUnitOfWork = logicUnitOfWork;
        }

        [HttpGet("GetLawList")]
        public ResponseModel<LawListModel> GetLawList([FromQuery] LawListFilterModel request)
        {
            ResponseModel<LawListModel> response;
            try
            {   
                var filter = new LawListFilterDto()
                {
                    Keyword = request.Keyword,
                    Catagory = request.Catagory,
                    ActType = request.ActType,
                    LegislationUnit = request.LegislationUnit,
                    AnnounceDate = request.AnnounceDate,
                    EnforceDate = request.EnforceDate,
                    CancelDate = request.CancelDate,
                    IsFilterByAnnounceDate = request.IsFilterByAnnounceDate,
                    IsFilterByEnforceDate = request.IsFilterByEnforceDate,
                    IsFilterByCancelDate = request.IsFilterByCancelDate
                };
                var result = _logicUnitOfWork.LawService.GetLawList(filter);
                response = new ResponseModel<LawListModel>
                {
                    Data = new LawListModel()
                    {
                        TotalLaw = result.TotalLaw,
                        LawList = result.LawList.Select(x => new LawModel()
                        {
                            LawId = x.LawId,
                            Title = x.Title,
                            LegislationType = x.LegislationType
                        }).ToList()
                    },
                    Message = "success",
                    Status = 200
                };
            }
            catch (ArgumentException e)
            {
                response = new ResponseModel<LawListModel>
                {
                    Data = null,
                    Message = e.Message,
                    Status = 400
                };
            }
            catch (Exception e)
            {
                response = new ResponseModel<LawListModel>
                {
                    Data = null,
                    Message = e.Message,
                    Status = 500
                };
            }
            return response;
        }

        [HttpPost("Add")]
        public ResponseModel<Law> GetLawbyId(
            string title,
            DateTime announceDate,
            DateTime? enforceDate,
            DateTime? cancelDate,
            string? pdfUrl,
            string catagory,
            string actType,
            string legislationType,
            string legislationUnit
         )
        {
            ResponseModel<Law> response;
            try
            {
                var newlaw = new Law()
                {
                    Id = Guid.NewGuid(),
                    Title = title,
                    AnnounceDate = announceDate,
                    EnforceDate = enforceDate,
                    CancelDate = cancelDate,
                    PdfUrl = pdfUrl,
                    Catagory = catagory,
                    ActType = actType,
                    LegislationType = legislationType,
                    LegislationUnit = legislationUnit
                };
                var result = _logicUnitOfWork.LawService.AddLaw(newlaw);
                response = new ResponseModel<Law>
                {
                    Data = newlaw,
                    Message = "success",
                    Status = 200
                };
            }
            catch (ArgumentException e)
            {
                response = new ResponseModel<Law>
                {
                    Data = null,
                    Message = e.Message,
                    Status = 400
                };
            }
            catch (Exception e)
            {
                response = new ResponseModel<Law>
                {
                    Data = null,
                    Message = e.Message,
                    Status = 500
                };
            }
            return response;
        }

        [HttpGet("GetLawDetailByTaskId")]
        public async Task<ResponseModel<LawDetailModel>> GetLawDetailByTaskId(Guid taskId)
        {
            ResponseModel<LawDetailModel> response;
            try
            {
                var result = await _logicUnitOfWork.LawService.GetLawDetailByTaskId(taskId);
                response = new ResponseModel<LawDetailModel>
                {
                    Data = new LawDetailModel()
                    {
                        Id = result.Id,
                        Title = result.Title,
                        LocationName = result.LocationName,
                        AnnounceDate = result.AnnounceDate,
                        EnforceDate = result.EnforceDate,
                        CancelDate = result.CancelDate,
                        PdfUrl = result.PdfUrl,
                        Catagory = result.Catagory,
                        ActType = result.ActType,
                        LegislationType = result.LegislationType,
                        LegislationUnit = result.LegislationUnit,
                        SystemList = result.SystemList
                    },
                    Message = "success",
                    Status = 200
                };
            }
            catch (ArgumentException e)
            {
                response = new ResponseModel<LawDetailModel>
                {
                    Data = null,
                    Message = e.Message,
                    Status = 400
                };
            }
            catch (Exception e)
            {
                response = new ResponseModel<LawDetailModel>
                {
                    Data = null,
                    Message = e.Message,
                    Status = 500
                };
            }
            return response;
        }

        [HttpGet("GetLawbyId")]
        public async Task<ResponseModel<LawDetailModel>> GetLawbyId(Guid lawId)
        {
            ResponseModel<LawDetailModel> response;
            try
            {
                var result = await _logicUnitOfWork.LawService.GetLawbyId(lawId);
                response = new ResponseModel<LawDetailModel>
                {
                    Data = new LawDetailModel()
                    {
                        Id = result.Id,
                        Title = result.Title,
                        LocationName = result.LocationName,
                        AnnounceDate = result.AnnounceDate,
                        EnforceDate = result.EnforceDate,
                        CancelDate = result.CancelDate,
                        PdfUrl = result.PdfUrl,
                        Catagory = result.Catagory,
                        ActType = result.ActType,
                        LegislationType = result.LegislationType,
                        LegislationUnit = result.LegislationUnit,
                        SystemList = result.SystemList
                    },
                    Message = "success",
                    Status = 200
                };
            }
            catch (ArgumentException e)
            {
                response = new ResponseModel<LawDetailModel>
                {
                    Data = null,
                    Message = e.Message,
                    Status = 400
                };
            }
            catch (Exception e)
            {
                response = new ResponseModel<LawDetailModel>
                {
                    Data = null,
                    Message = e.Message,
                    Status = 500
                };
            }
            return response;
        }

        [HttpGet("GetActTypeName")]
        public ResponseModel<List<NameDataDto>> GetActTypeName()
        {
            ResponseModel<List<NameDataDto>> response;
            try
            {
                var result = _logicUnitOfWork.LawService.GetActTypeName();
                response = new ResponseModel<List<NameDataDto>>
                {
                    Data = result,
                    Message = "success",
                    Status = 200
                };
            }
            catch (ArgumentException e)
            {
                response = new ResponseModel<List<NameDataDto>>
                {
                    Data = null,
                    Message = e.Message,
                    Status = 400
                };
            }
            catch (Exception e)
            {
                response = new ResponseModel<List<NameDataDto>>
                {
                    Data = null,
                    Message = e.Message,
                    Status = 500
                };
            }
            return response;
        }
        [HttpGet("GetLegislationUnitName")]
        public ResponseModel<List<NameDataDto>> GetLegislationUnitName()
        {
            ResponseModel<List<NameDataDto>> response;
            try
            {
                var result = _logicUnitOfWork.LawService.GetLegislationUnitName();
                response = new ResponseModel<List<NameDataDto>>
                {
                    Data = result,
                    Message = "success",
                    Status = 200
                };
            }
            catch (ArgumentException e)
            {
                response = new ResponseModel<List<NameDataDto>>
                {
                    Data = null,
                    Message = e.Message,
                    Status = 400
                };
            }
            catch (Exception e)
            {
                response = new ResponseModel<List<NameDataDto>>
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
