using RegulationAssessment.Logic.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegulationAssessment.Logic.UnitOfWork.Interface
{
    public interface ILogicUnitOfWork
    {
        ITaskService TaskService { get; set; }
        IEmployeeService EmployeeService { get; set; }
        ILawService LawService { get; set; }
    }
}
