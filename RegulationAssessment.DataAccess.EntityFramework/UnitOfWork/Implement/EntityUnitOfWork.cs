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
        private RAContext _dbContext;

        private IEntityFrameworkNpgsqlRepository<Models.Task> _taskRepository;
        private IEntityFrameworkNpgsqlRepository<Business> _businessRepository;
        private IEntityFrameworkNpgsqlRepository<Employee> _employeeRepository;
        private IEntityFrameworkNpgsqlRepository<BusinessLine> _businessLineRepository;
        private IEntityFrameworkNpgsqlRepository<CommiteeGroup> _commiteeGroupRepository;
        private IEntityFrameworkNpgsqlRepository<Duty> _dutyRepository;
        private IEntityFrameworkNpgsqlRepository<ImplementUnit> _implementUnitRepository;
        private IEntityFrameworkNpgsqlRepository<KeyAction> _keyActionRepository;
        private IEntityFrameworkNpgsqlRepository<Law> _lawRepository;
        private IEntityFrameworkNpgsqlRepository<Location> _locationRepository;
        private IEntityFrameworkNpgsqlRepository<Logging> _loggingRepository;
        private IEntityFrameworkNpgsqlRepository<Notification> _notificationRepository;
        private IEntityFrameworkNpgsqlRepository<RelatedBusiness> _relatedBusinessRepository;
        private IEntityFrameworkNpgsqlRepository<RelatedSystem> _relatedSystemRepository;
        private IEntityFrameworkNpgsqlRepository<Responsibility> _responsibilityRepository;
        private IEntityFrameworkNpgsqlRepository<Role> _roleRepository;
        private IEntityFrameworkNpgsqlRepository<Models.System> _systemRepository;

        public EntityUnitOfWork(RAContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEntityFrameworkNpgsqlRepository<Models.Task> TaskRepository
        {
            get { return _taskRepository ?? (_taskRepository = new EntityFrameworkNpgsqlRepository<Models.Task>(_dbContext)); }
            set { _taskRepository = value; }
        }
        public IEntityFrameworkNpgsqlRepository<Business> BusinessRepository
        {
            get { return _businessRepository ?? (_businessRepository = new EntityFrameworkNpgsqlRepository<Business>(_dbContext)); }
            set { _businessRepository = value; }
        }
        public IEntityFrameworkNpgsqlRepository<Employee> EmployeeRepository
        {
            get { return _employeeRepository ?? (_employeeRepository = new EntityFrameworkNpgsqlRepository<Employee>(_dbContext)); }
            set { _employeeRepository = value; }
        }
        public IEntityFrameworkNpgsqlRepository<BusinessLine> BusinessLineRepository
        {
            get { return _businessLineRepository ?? (_businessLineRepository = new EntityFrameworkNpgsqlRepository<BusinessLine>(_dbContext)); }
            set { _businessLineRepository = value; }
        }
        public IEntityFrameworkNpgsqlRepository<CommiteeGroup> CommiteeGroupRepository
        {
            get { return _commiteeGroupRepository ?? (_commiteeGroupRepository = new EntityFrameworkNpgsqlRepository<CommiteeGroup>(_dbContext)); }
            set { _commiteeGroupRepository = value; }
        }
        public IEntityFrameworkNpgsqlRepository<Duty> DutyRepository
        {
            get { return _dutyRepository ?? (_dutyRepository = new EntityFrameworkNpgsqlRepository<Duty>(_dbContext)); }
            set { _dutyRepository = value; }
        }
        public IEntityFrameworkNpgsqlRepository<ImplementUnit> ImplementUnitRepository
        {
            get { return _implementUnitRepository ?? (_implementUnitRepository = new EntityFrameworkNpgsqlRepository<ImplementUnit>(_dbContext)); }
            set { _implementUnitRepository = value; }
        }
        public IEntityFrameworkNpgsqlRepository<KeyAction> KeyActionRepository
        {
            get { return _keyActionRepository ?? (_keyActionRepository = new EntityFrameworkNpgsqlRepository<KeyAction>(_dbContext)); }
            set { _keyActionRepository = value; }
        }
        public IEntityFrameworkNpgsqlRepository<Law> LawRepository
        {
            get { return _lawRepository ?? (_lawRepository = new EntityFrameworkNpgsqlRepository<Law>(_dbContext)); }
            set { _lawRepository = value; }
        }
        public IEntityFrameworkNpgsqlRepository<Location> LocationRepository
        {
            get { return _locationRepository ?? (_locationRepository = new EntityFrameworkNpgsqlRepository<Location>(_dbContext)); }
            set { _locationRepository = value; }
        }
        public IEntityFrameworkNpgsqlRepository<Logging> LoggingRepository
        {
            get { return _loggingRepository ?? (_loggingRepository = new EntityFrameworkNpgsqlRepository<Logging>(_dbContext)); }
            set { _loggingRepository = value; }
        }
        public IEntityFrameworkNpgsqlRepository<Notification> NotificationRepository
        {
            get { return _notificationRepository ?? (_notificationRepository = new EntityFrameworkNpgsqlRepository<Notification>(_dbContext)); }
            set { _notificationRepository = value; }
        }
        public IEntityFrameworkNpgsqlRepository<RelatedBusiness> RelatedBusinessRepository
        {
            get { return _relatedBusinessRepository ?? (_relatedBusinessRepository = new EntityFrameworkNpgsqlRepository<RelatedBusiness>(_dbContext)); }
            set { _relatedBusinessRepository = value; }
        }
        public IEntityFrameworkNpgsqlRepository<RelatedSystem> RelatedSystemRepository
        {
            get { return _relatedSystemRepository ?? (_relatedSystemRepository = new EntityFrameworkNpgsqlRepository<RelatedSystem>(_dbContext)); }
            set { _relatedSystemRepository = value; }
        }
        public IEntityFrameworkNpgsqlRepository<Responsibility> ResponsibilityRepository
        {
            get { return _responsibilityRepository ?? (_responsibilityRepository = new EntityFrameworkNpgsqlRepository<Responsibility>(_dbContext)); }
            set { _responsibilityRepository = value; }
        }
        public IEntityFrameworkNpgsqlRepository<Role> RoleRepository
        {
            get { return _roleRepository ?? (_roleRepository = new EntityFrameworkNpgsqlRepository<Role>(_dbContext)); }
            set { _roleRepository = value; }
        }
        public IEntityFrameworkNpgsqlRepository<Models.System> SystemRepository
        {
            get { return _systemRepository ?? (_systemRepository = new EntityFrameworkNpgsqlRepository<Models.System>(_dbContext)); }
            set { _systemRepository = value; }
        }
        public async Task<int> SaveAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}
