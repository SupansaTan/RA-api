using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using RegulationAssessment.DataAccess.EntityFramework.Models;
using RegulationAssessment.DataAccess.EntityFramework.UnitOfWork.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegulationAssessment.DataAccess.EntityFramework.UnitOfWork.Implement
{
    public class EntityUnitOfWork : IEntityUnitOfWork
    {
        private RaContext _dbContext;

        private IEntityFrameworkNpgsqlRepository<Tasks> _taskRepository;

        public EntityUnitOfWork(RaContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEntityFrameworkNpgsqlRepository<Tasks> TaskRepository
        {
            get { return _taskRepository ?? (_taskRepository = new EntityFrameworkNpgsqlRepository<Tasks>(_dbContext)); }

            set { _taskRepository = value; }
        }

        public async Task<int> SaveAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}
