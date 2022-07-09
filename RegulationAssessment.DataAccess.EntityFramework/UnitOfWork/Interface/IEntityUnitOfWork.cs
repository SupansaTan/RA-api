using RegulationAssessment.DataAccess.EntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegulationAssessment.DataAccess.EntityFramework.UnitOfWork.Interface
{
    public interface IEntityUnitOfWork
    {
        Task<int> SaveAsync();
        IEntityFrameworkNpgsqlRepository<Models.Task> TaskRepository { get; set; }
        IEntityFrameworkNpgsqlRepository<Business> BusinessRepository { get; set; }
        IEntityFrameworkNpgsqlRepository<Employee> EmployeeRepository { get; set; }
        IEntityFrameworkNpgsqlRepository<BusinessLine> BusinessLineRepository { get; set; }
        IEntityFrameworkNpgsqlRepository<CommiteeGroup> CommiteeGroupRepository { get; set; }
        IEntityFrameworkNpgsqlRepository<Duty> DutyRepository { get; set; }
        IEntityFrameworkNpgsqlRepository<ImplementUnit> ImplementUnitRepository { get; set; }
        IEntityFrameworkNpgsqlRepository<KeyAction> KeyActionRepository { get; set; }
        IEntityFrameworkNpgsqlRepository<Law> LawRepository { get; set; }
        IEntityFrameworkNpgsqlRepository<Location> LocationRepository { get; set; }
        IEntityFrameworkNpgsqlRepository<Logging> LoggingRepository { get; set; }
        IEntityFrameworkNpgsqlRepository<Notification> NotificationRepository { get; set; }
        IEntityFrameworkNpgsqlRepository<RelatedBusiness> RelatedBusinessRepository { get; set; }
        IEntityFrameworkNpgsqlRepository<RelatedSystem> RelatedSystemRepository { get; set; }
        IEntityFrameworkNpgsqlRepository<Responsibility> ResponsibilityRepository { get; set; }
        IEntityFrameworkNpgsqlRepository<Role> RoleRepository { get; set; }
        IEntityFrameworkNpgsqlRepository<Models.System> SystemRepository { get; set; }
    }
}
