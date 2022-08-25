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
                                                                    Id = x.Id,
                                                                    Ssn = x.Ssn,
                                                                    FirstName = x.FirstName,
                                                                    LastName = x.LastName,
                                                                    CreateAt = x.CreateAt,
                                                                    Email = x.Email,
                                                                    Password = x.Password,
                                                                    DarkTheme = x.DarkTheme,
                                                                    NotificationStatus = x.NotificationStatus,
                                                                    AdvanceNotify = x.AdvanceNotify,
                                                                }).ToList();
            return employees;
        }

        public List<EmployeeDto> GetEmployeeById(Guid empId)
        {
            var employee = _entityUnitOfWork.EmployeeRepository.GetAll(x => x.Id == empId)
                                                                .Select(x => new EmployeeDto()
                                                                {
                                                                    FirstName = x.FirstName,
                                                                    LastName = x.LastName,
                                                                    DarkTheme = (bool)x.DarkTheme,
                                                                    NotificationStatus = x.NotificationStatus,
                                                                    AdvanceNotify = x.AdvanceNotify,
                                                                }).ToList();
            return employee;
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
                    RoleList = roleList
                };
                return result;
            }
        }
    }
}
