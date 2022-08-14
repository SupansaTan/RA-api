using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RegulationAssessment.DataAccess.Dapper.Interface;
using RegulationAssessment.DataAccess.EntityFramework.UnitOfWork.Interface;
using RegulationAssessment.Logic.Services.Implements;
using RegulationAssessment.Logic.Services.Interfaces;
using RegulationAssessment.Logic.UnitOfWork.Interface;

namespace RegulationAssessment.Logic.UnitOfWork.Implement
{
    public class LogicUnitOfWork : ILogicUnitOfWork
    {
        private IEntityUnitOfWork _entityUnitOfWork { get; set; }
        private IDapperUnitOfWork _dapperUnitOfWork { get; set; }

        public LogicUnitOfWork(
            IEntityUnitOfWork entityUnitOfWork,
            IDapperUnitOfWork dapperUnitOfWork
            )
        {
            _entityUnitOfWork = entityUnitOfWork;
            _dapperUnitOfWork = dapperUnitOfWork;
        }

        private ITaskService _taskService;

        public ITaskService TaskService
        {
            get { return _taskService ?? (_taskService = new TaskService(_entityUnitOfWork, _dapperUnitOfWork)); }
            set { _taskService = value; }
        }

        private IEmployeeService _employeeService;

        public IEmployeeService EmployeeService
        {
            get { return _employeeService ?? (_employeeService = new EmployeeService(_entityUnitOfWork)); }
            set { _employeeService = value; }
        }
    }
}
