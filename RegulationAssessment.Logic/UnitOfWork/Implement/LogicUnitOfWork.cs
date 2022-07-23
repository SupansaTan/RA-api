using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RegulationAssessment.DataAccess.EntityFramework.UnitOfWork.Interface;
using RegulationAssessment.Logic.Services.Implements;
using RegulationAssessment.Logic.Services.Interfaces;
using RegulationAssessment.Logic.UnitOfWork.Interface;

namespace RegulationAssessment.Logic.UnitOfWork.Implement
{
    public class LogicUnitOfWork : ILogicUnitOfWork
    {
        private IEntityUnitOfWork _entityUnitOfWork { get; set; }

        public LogicUnitOfWork(
            IEntityUnitOfWork entityUnitOfWork
            )
        {
            _entityUnitOfWork = entityUnitOfWork;
        }

        private ITaskService _taskService;

        public ITaskService TaskService
        {
            get { return _taskService ?? (_taskService = new TaskService(_entityUnitOfWork)); }
            set { _taskService = value; }
        }
    }
}
