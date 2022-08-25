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
    public class LocationController : ControllerBase
    {
        private readonly ILogicUnitOfWork _logicUnitOfWork;
        public LocationController(ILogicUnitOfWork logicUnitOfWork)
        {
            _logicUnitOfWork = logicUnitOfWork;
        }

        [HttpGet("GetLocationListByEmpId")]
        public async Task<ResponseModel<List<LocationListModel>>> GetLocationListByEmpId([FromQuery] Guid empId)
        {
            ResponseModel<List<LocationListModel>> response;
            try
            {
                var result = await _logicUnitOfWork.LocationService.GetLocationListByEmpId(empId);
                response = new ResponseModel<List<LocationListModel>>
                {
                    Data = result.Select(x => new LocationListModel()
                    {
                        LocationId = x.LocationId,
                        LocationName = x.LocationName,
                        BusinessType = x.BusinessType
                    }).ToList(),
                    Message = "success",
                    Status = 200
                };
            }
            catch (ArgumentException e)
            {
                response = new ResponseModel<List<LocationListModel>>
                {
                    Data = null,
                    Message = e.Message,
                    Status = 400
                };
            }
            catch (Exception e)
            {
                response = new ResponseModel<List<LocationListModel>>
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
