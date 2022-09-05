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
        public async Task<ResponseModel<EmployeeModel>> GetEmployee(Guid empId)
        {
            ResponseModel<EmployeeModel> response;
            try
            {
                var result = await _logicUnitOfWork.EmployeeService.GetEmployeeById(empId);
                response = new ResponseModel<EmployeeModel>
                {
                    Data = new EmployeeModel()
                    {
                        FirstName = result.FirstName,
                        LastName = result.LastName,
                        DarkTheme = result.DarkTheme,
                        NotificationStatus = result.NotificationStatus,
                        AdvanceNotify = result.AdvanceNotify,
                    },
                    Message = "success",
                    Status = 200
                };
            }
            catch (ArgumentException e)
            {
                response = new ResponseModel<EmployeeModel>
                {
                    Data = null,
                    Message = e.Message,
                    Status = 400
                };
            }
            catch (Exception e)
            {
                response = new ResponseModel<EmployeeModel>
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
                        FirstName = result.FirstName,
                        LastName = result.LastName,
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

        [HttpPut("UpdateEmployeeInfo")]
        public async Task<ResponseModel<bool>> UpdateEmployeeInfo([FromBody] UpdateEmployeeInfoModel request)
        {
            ResponseModel<bool> response;
            try
            {
                var empInfo = new UpdateEmployeeInfoDto()
                {
                    EmployeeId = request.EmployeeId,
                    NotificationStatus = request.NotificationStatus,
                    AdvanceNotify = request.AdvanceNotify,
                    DarkTheme = request.DarkTheme,
                };

                response = new ResponseModel<bool>
                {
                    Data = await _logicUnitOfWork.EmployeeService.UpdateEmployeeInfo(empInfo),
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

        [HttpGet("GetEmployeeList")]
        public async Task<ResponseModel<List<EmployeeInfoModel>>> GetEmployeeList([FromQuery] Guid taskId)
        {
            ResponseModel<List<EmployeeInfoModel>> response;
            try
            {
                var result = await _logicUnitOfWork.EmployeeService.GetEmployeeList(taskId);
                response = new ResponseModel<List<EmployeeInfoModel>>
                {
                    Data = result.Select(x => new EmployeeInfoModel()
                    {
                        EmployeeId = x.EmployeeId,
                        Name = x.Name,
                    }).ToList(),
                    Message = "success",
                    Status = 200
                };
            }
            catch (ArgumentException e)
            {
                response = new ResponseModel<List<EmployeeInfoModel>>
                {
                    Data = null,
                    Message = e.Message,
                    Status = 400
                };
            }
            catch (Exception e)
            {
                response = new ResponseModel<List<EmployeeInfoModel>>
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
