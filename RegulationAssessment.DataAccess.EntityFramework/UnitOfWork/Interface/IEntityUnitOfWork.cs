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
        IEntityFrameworkNpgsqlRepository<Tasks> TaskRepository { get; set; }
    }
}
