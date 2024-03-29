using RegulationAssessment.Logic.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegulationAssessment.Logic.Services.Interfaces
{
    public interface IEmployeeService
    {
        Task<EmployeeDto> GetEmployeeById(Guid empId);
        Task<EmployeeProfileDto> GetEmployeeProfile(Guid empId);
        Task<bool> UpdateEmployeeInfo(UpdateEmployeeInfoDto model);
        Task<List<EmployeeInfoDto>> GetEmployeeList(Guid taskId);
    }
}
