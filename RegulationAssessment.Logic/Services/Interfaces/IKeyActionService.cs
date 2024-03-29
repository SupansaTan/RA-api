using RegulationAssessment.DataAccess.EntityFramework.Models;
using RegulationAssessment.Logic.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegulationAssessment.Logic.Services.Interfaces
{
    public interface IKeyActionService
    {
        Task<List<KeyActionDto>> GetAllKeyAction(Guid taskId);
    }
}