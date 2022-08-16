using RegulationAssessment.DataAccess.EntityFramework.UnitOfWork.Interface;
using RegulationAssessment.Logic.DomainModel;
using RegulationAssessment.Logic.Services.Interfaces;
using RegulationAssessment.Common.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegulationAssessment.Logic.Services.Implements
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEntityUnitOfWork _entityUnitOfWork;

        public EmployeeService(IEntityUnitOfWork entityUnitOfWork)
        {
            _entityUnitOfWork = entityUnitOfWork;
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
            return employee;
        }

    }
}
