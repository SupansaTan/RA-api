using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RegulationAssessment.Api.Models;
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
    public class ResponsibilityController : ControllerBase
    {
        private readonly ILogicUnitOfWork _logicUnitOfWork;
        public ResponsibilityController(ILogicUnitOfWork logicUnitOfWork)
        {
            _logicUnitOfWork = logicUnitOfWork;
        }

        [HttpGet("GetTrackingDataByLocationId")]
        public async Task<ResponseModel<ResponsibilityListDto>> GetTrackingDataByLocationId([FromQuery] Guid locationId)
        {
            ResponseModel<ResponsibilityListDto> response;
            try
            {
                var result = await _logicUnitOfWork.ResponsibilityService.GetTrackingDataByLocationId(locationId);
                response = new ResponseModel<ResponsibilityListDto>
                {
                    Data = result,
                    Message = "success",
                    Status = 200
                };
            }
            catch (ArgumentException e)
            {
                response = new ResponseModel<ResponsibilityListDto>
                {
                    Data = null,
                    Message = e.Message,
                    Status = 400
                };
            }
            catch (Exception e)
            {
                response = new ResponseModel<ResponsibilityListDto>
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