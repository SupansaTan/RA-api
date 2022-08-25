using Microsoft.AspNetCore.Http;
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
    public class EmployeeController : ControllerBase
    {
        private readonly ILogicUnitOfWork _logicUnitOfWork;
        public EmployeeController(ILogicUnitOfWork logicUnitOfWork)
        {
            _logicUnitOfWork = logicUnitOfWork;
        }

        [HttpGet("GetAllEmployees")]
        public ResponseModel<List<EmployeeModel>> GetAllEmployees()
        {
            ResponseModel<List<EmployeeModel>> response;
            try
            {
                var result = _logicUnitOfWork.EmployeeService.GetAllEmployees();
                response = new ResponseModel<List<EmployeeModel>>
                {
                    Data = result.Select(x => new EmployeeModel()
                    {
                        FirstName = x.FirstName,
                        LastName = x.LastName,
                        DarkTheme = x.DarkTheme,
                        NotificationStatus = x.NotificationStatus,
                        AdvanceNotify = x.AdvanceNotify,
                    }).ToList(),
                    Message = "success",
                    Status = 200
                };
            }
            catch (ArgumentException e)
            {
                response = new ResponseModel<List<EmployeeModel>>
                {
                    Data = null,
                    Message = e.Message,
                    Status = 400
                };
            }
            catch (Exception e)
            {
                response = new ResponseModel<List<EmployeeModel>>
                {
                    Data = null,
                    Message = e.Message,
                    Status = 500
                };
            }
            return response;
        }

        [HttpGet("GetEmployee")]
        public ResponseModel<List<EmployeeModel>> GetEmployee(Guid empId)
        {
            ResponseModel<List<EmployeeModel>> response;
            try
            {
                var result = _logicUnitOfWork.EmployeeService.GetEmployeeById(empId);
                response = new ResponseModel<List<EmployeeModel>>
                {
                    Data = result.Select(x => new EmployeeModel()
                    {
                        FirstName = x.FirstName,
                        LastName = x.LastName,
                        DarkTheme = x.DarkTheme,
                        NotificationStatus = x.NotificationStatus,
                        AdvanceNotify = x.AdvanceNotify,
                    }).ToList(),
                    Message = "success",
                    Status = 200
                };
            }
            catch (ArgumentException e)
            {
                response = new ResponseModel<List<EmployeeModel>>
                {
                    Data = null,
                    Message = e.Message,
                    Status = 400
                };
            }
            catch (Exception e)
            {
                response = new ResponseModel<List<EmployeeModel>>
                {
                    Data = null,
                    Message = e.Message,
                    Status = 500
                };
            }
            return response;
        }

        [HttpGet("GetEmployeeProfile")]
        public async Task<ResponseModel<EmployeeProfileModel>> GetEmployeeProfile([FromQuery] Guid empId)
        {
            ResponseModel<EmployeeProfileModel> response;
            try
            {
                var result = await _logicUnitOfWork.EmployeeService.GetEmployeeProfile(empId);
                response = new ResponseModel<EmployeeProfileModel>
                {
                    Data = new EmployeeProfileModel()
                    {
                        Email = result.Email,
                        RoleList = result.RoleList.Select(x => new RoleInfoModel()
                        {
                            RoleName = x.RoleName,
                            Location = x.Location
                        }).ToList()
                    },
                    Message = "success",
                    Status = 200
                };
            }
            catch (ArgumentException e)
            {
                response = new ResponseModel<EmployeeProfileModel>
                {
                    Data = null,
                    Message = e.Message,
                    Status = 400
                };
            }
            catch (Exception e)
            {
                response = new ResponseModel<EmployeeProfileModel>
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
