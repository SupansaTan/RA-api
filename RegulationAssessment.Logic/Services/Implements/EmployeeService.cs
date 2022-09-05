using RegulationAssessment.DataAccess.EntityFramework.UnitOfWork.Interface;
using RegulationAssessment.Logic.DomainModel;
using RegulationAssessment.Logic.Services.Interfaces;
using RegulationAssessment.Common.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RegulationAssessment.Common.Helper;
using RegulationAssessment.DataAccess.Dapper.Interface;
using RegulationAssessment.DataAccess.EntityFramework.Models;
using Microsoft.EntityFrameworkCore;

namespace RegulationAssessment.Logic.Services.Implements
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEntityUnitOfWork _entityUnitOfWork;
        private readonly IDapperUnitOfWork _dapperUnitOfWork;
        private readonly string QUERY_PATH;

        public EmployeeService(
            IEntityUnitOfWork entityUnitOfWork,
            IDapperUnitOfWork dapperUnitOfWork)
        {
            QUERY_PATH = this.GetType().Name.Split("Service")[0] + "/";
            _entityUnitOfWork = entityUnitOfWork;
            _dapperUnitOfWork = dapperUnitOfWork;
        }

        public List<EmployeeDto> GetAllEmployees()
        {
            var employees = _entityUnitOfWork.EmployeeRepository.GetAll()
                                                                .Select(x => new EmployeeDto()
                                                                {
                                                                    FirstName = x.FirstName,
                                                                    LastName = x.LastName,
                                                                    CreateAt = x.CreateAt,
                                                                    DarkTheme = (bool)x.DarkTheme,
                                                                    NotificationStatus = x.NotificationStatus,
                                                                    AdvanceNotify = x.AdvanceNotify,
                                                                }).ToList();
            return employees;
        }

        public async Task<EmployeeDto> GetEmployeeById(Guid empId)
        {
            var employee = await _entityUnitOfWork.EmployeeRepository.GetSingleAsync(x => x.Id == empId);
            if (employee == null)
            {
                throw new ArgumentException("Employee does not exist.");
            }
            else
            {
                var result = new EmployeeDto()
                {
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    DarkTheme = (bool)employee.DarkTheme,
                    NotificationStatus = employee.NotificationStatus,
                    AdvanceNotify = employee.AdvanceNotify,
                };
                return result;
            }
        }

        public async Task<EmployeeProfileDto> GetEmployeeProfile(Guid empId)
        {
            var employee = await _entityUnitOfWork.EmployeeRepository.GetSingleAsync(x => x.Id == empId);
            if (employee == null)
            {
                throw new ArgumentException("Employee does not exist.");
            }
            else
            {
                var employeeRole = await _entityUnitOfWork.DutyRepository.GetSingleAsync(x => x.EmpId == empId);
                var queryGetRoleList = QueryService.GetCommand(QUERY_PATH + "getRoleList",
                            new ParamCommand { Key = "_employeeId", Value = empId.ToString() }
                        );
                var roleList = (await _dapperUnitOfWork.RARepository.QueryAsync<RoleInfoDto>(queryGetRoleList)).ToList();
                var result = new EmployeeProfileDto()
                {
                    Email = employee.Email,
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    RoleList = roleList
                };
                return result;
            }
        }

        public async Task<bool> UpdateEmployeeInfo(UpdateEmployeeInfoDto model)
        {
            var employee = await _entityUnitOfWork.EmployeeRepository.GetSingleAsync(x => x.Id == model.EmployeeId);
            if (employee == null)
            {
                throw new ArgumentException("Employee does not exist.");
            }
            else
            {
                employee.DarkTheme = model.DarkTheme;
                employee.AdvanceNotify = model.AdvanceNotify;
                employee.NotificationStatus = model.NotificationStatus;
                _entityUnitOfWork.EmployeeRepository.Update(employee);
                await _entityUnitOfWork.SaveAsync();
                return true;
            }
        }
        public async Task<List<EmployeeInfoDto>> GetEmployeeList(Guid locationId)
        {
            var employee = await _entityUnitOfWork.DutyRepository.GetAll(x => x.Emp, x => x.Role)
                                                                 .Where(x => x.LocationId == locationId && x.Role.Name == "Employee")
                                                                 .ToListAsync();
            var result = employee.Select(x => new EmployeeInfoDto()
            {
                EmployeeId = x.EmpId,
                FirstName = x.Emp.FirstName,
                LastName = x.Emp.LastName
            }).ToList();
            return result;
        }
    }
}
